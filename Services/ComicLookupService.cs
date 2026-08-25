using System;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ComicCollection.Models;
using System.Windows.Forms;

namespace ComicCollection.Services
{
    public class ComicLookupService
    {
        private readonly HttpClient _httpClient;
        private readonly string _connectionString;

        public ComicLookupService()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0"
            );

            _httpClient.DefaultRequestHeaders.Add(
                "Accept",
                "application/json"
            );

            string databasePath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "GCDIndex.db"
            );

            _connectionString = $"Data Source={databasePath}";
        }

        public List<int> FindGCDIssueIds(string upc)
        {
            List<int> issueIds = new List<int>();

            using var connection = new SqliteConnection(_connectionString);

            connection.Open();

            string sql = @"
                SELECT GCDIssueId
                FROM GCDIssueIndex
                WHERE UPC = $upc;
                ORDER BY GCDIssueId;
            ";

            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("$upc", upc);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                issueIds.Add(reader.GetInt32(0));
            }

            return issueIds;
        }

        // retrieving comic info from GCD website API
        public async Task<Comic?> GetGCDIssueAsync(int issueId)
        {
            string url = $"https://www.comics.org/api/issue/{issueId}/";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            using JsonDocument document = JsonDocument.Parse(json);

            JsonElement root = document.RootElement;

            string seriesName = root.GetProperty("series_name").GetString() ?? "";
            string issueNumber = root.GetProperty("number").GetString() ?? "";
            string barcode = root.GetProperty("barcode").GetString() ?? "";
            string publisher = root.GetProperty("indicia_publisher").GetString() ?? "";

            int? releaseYear = null;

            string keyDate = root.GetProperty("key_date").GetString() ?? "";

            //// set release year if we can find it
            if (keyDate.Length >= 4 && int.TryParse(keyDate.Substring(0, 4), out int year))
            {
                releaseYear = year;
            }

            string? coverPath = null;

            //// retrueve cover URL if it's available
            if (root.TryGetProperty("cover", out JsonElement coverElement) && coverElement.ValueKind != JsonValueKind.Null)
            {
                coverPath = coverElement.GetString();
            }

            Comic comic = new Comic
            {
                Title = seriesName,
                IssueNumber = issueNumber,
                Publisher = publisher,
                ReleaseYear = releaseYear,
                UPC = string.IsNullOrWhiteSpace(barcode) ? null : barcode,
                CoverPath = coverPath
            }
            ;
            return comic;
        }

        // Find Comic using UPC
        public async Task<Comic?> GetComicByUPCAsync(string upc)
        {
            List<int> issueIds = FindGCDIssueIds(upc);

            // Comic not found
            if(issueIds.Count == 0)
            {
                return null;
            }

            // More than one comic found
            if (issueIds.Count > 1)
            {
                throw new InvalidOperationException(
                    $"The UPC returned {issueIds.Count} comics. " + "This UPC cannot be automatically identified.");
            }
            // Retrieve comic information from GCD
            return await GetGCDIssueAsync(issueIds[0]);
        }
    }
}