using Microsoft.Data.Sqlite;
using ComicCollection.Models;
using System.Collections.Generic;

namespace ComicCollection.Data
{
    internal class Database
    {
        // use database called "comics.db"
        private const string ConnectionString = "Data Source=comics.db";

        public void Initialize()
        {
            using var connection = new SqliteConnection(ConnectionString);

            // open database
            connection.Open();

            // send sql query to create comic table if it doesn't exist
            string sql = @"
                CREATE TABLE IF NOT EXISTS Comics (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    IssueNumber TEXT NOT NULL,
                    Publisher TEXT NOT NULL,
                    ReleaseYear INTEGER,
                    UPC TEXT,
                    CoverPath TEXT
                );
            ";

            using var command = new SqliteCommand(sql, connection);

            command.ExecuteNonQuery();
        }

        // method to add comic to database
        public int AddComic(Comic comic)
        {
            using var connection = new SqliteConnection(ConnectionString);

            connection.Open();

            // sql query to insert new comic entry
            string sql = @"
                INSERT INTO Comics (Title, IssueNumber, Publisher, ReleaseYear, UPC)
                VALUES ($title, $issueNumber, $publisher, $releaseYear, $upc);
            ";

            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("$title", comic.Title);
            command.Parameters.AddWithValue("$issueNumber", comic.IssueNumber);
            command.Parameters.AddWithValue("$publisher", comic.Publisher);
            command.Parameters.AddWithValue("$releaseYear",
                (object?)comic.ReleaseYear ?? DBNull.Value);
            command.Parameters.AddWithValue("$upc",
                (object?)comic.UPC ?? DBNull.Value);

            command.ExecuteNonQuery();

            // Get ID SQLite assigned to added comic
            using var idCommand = new SqliteCommand(
                "SELECT last_insert_rowid();",
                connection
                );

            long id = (long)idCommand.ExecuteScalar()!;

            return (int)id;
        }

        // method to delete comics from database
        public void DeleteComic(int id)
        {
            using var connection = new SqliteConnection(ConnectionString);

            // open database
            connection.Open();

            // send sql query to delete comic from database
            string sql = @"
                DELETE FROM Comics
                WHERE Id = $id;
            ";

            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("$id", id);

            command.ExecuteNonQuery();
        }

        // get comics for datagrid
        public List<Comic> GetComics(string search ="")
        {
            List<Comic> comics = new List<Comic>();

            using var connection = new SqliteConnection(ConnectionString);

            connection.Open();

            string sql = @"
                SELECT Id, Title, IssueNumber, Publisher, ReleaseYear, UPC, CoverPath
                FROM Comics
                WHERE Title LIKE $search
                    OR IssueNumber LIKE $search
                    OR Publisher LIKE $search
                    OR CAST(ReleaseYear AS TEXT) LIKE $search
                ORDER BY id;
            ";

            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("$search", $"%{search}%");

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Comic comic = new Comic
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    IssueNumber = reader.GetString(2),
                    Publisher = reader.GetString(3),
                    ReleaseYear = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                    UPC = reader.IsDBNull(5) ? null : reader.GetString(5),
                    CoverPath = reader.IsDBNull(6) ? null : reader.GetString(6)
                };

                comics.Add(comic);
            }

            return comics;
        }

        // Update cover path for existing comic
        public void UpdateCoverPath(int comicId, string coverPath)
        {
            using var connection = new SqliteConnection(ConnectionString);

            connection.Open();

            string sql = @"
                UPDATE Comics
                SET CoverPath = $coverPath
                WHERE Id = $id;
            ";

            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("$coverPath", coverPath);
            command.Parameters.AddWithValue("$id", comicId);

            command.ExecuteNonQuery();
        }

        public Comic? GetComic(int id)
        {
            using var connection = new SqliteConnection(ConnectionString);

            connection.Open();

            string sql = @"
                SELECT Id, Title, IssueNumber, Publisher, ReleaseYear, UPC, CoverPath
                FROM Comics
                WHERE Id = $id;
            ";

            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return new Comic
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                IssueNumber = reader.GetString(2),
                Publisher = reader.GetString(3),
                ReleaseYear = reader.IsDBNull(4)
                    ? null
                    : reader.GetInt32(4),
                UPC = reader.IsDBNull(5)
                    ? null
                    : reader.GetString(5),
                CoverPath = reader.IsDBNull(6)
                    ? null
                    : reader.GetString(6)
            };
        }
    }
}