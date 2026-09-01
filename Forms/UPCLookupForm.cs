using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComicCollection.Models;
using ComicCollection.Services;
using System.Net.Http;
using ComicCollection.Data;
using ComicCollection.Helpers;
using ComicCollection.Styles;
using Microsoft.Web.WebView2.WinForms;

namespace ComicCollection.Forms
{
    public partial class UPCLookupForm : Form
    {

        private string? _gcdCoverURL;
        private readonly ComicLookupService _lookupService;
        private readonly WebView2 _coverWebView;
        private readonly CoverService _coverService;
        public UPCLookupForm()
        {
            InitializeComponent();

            _lookupService = new ComicLookupService();
            _coverWebView = new WebView2();

            _coverWebView.Visible = false;

            Controls.Add(_coverWebView);

            _coverService = new CoverService(_coverWebView);

            ApplyTheme();

            // start with comic info fields disabled
            SetComicFieldsEnabled(false);

            // enter adds comic
            this.AcceptButton = AddComicUPCButton;

            StatusLabel.Text = "";

            UPCTextBox.Focus();
        }

        // clear all comic result fields
        private void ClearComicFields()
        {
            TitleTextBox.Clear();
            IssueTextBox.Clear();
            PublisherTextBox.Clear();
            ReleaseYearTextBox.Clear();

            _gcdCoverURL = null;

            // disable editing fields when results are reset
            SetComicFieldsEnabled(false);
        }

        // button for searching the UPC
        private async void SearchUPCButton_Click(object sender, EventArgs e)
        {
            string upc = UPCTextBox.Text.Trim();

            // normalize & validate UPC and remove whitespace
            string normalizedUPC = new string(upc.Where(char.IsDigit).ToArray());

            // if no UPC is entered
            if (string.IsNullOrWhiteSpace(normalizedUPC))
            {
                StatusLabel.Text = "Please enter a UPC";
                UPCTextBox.Focus();
                return;
            }

            // search for comics...
            try
            {
                // disable button and display status while searching
                SearchUPCButton.Enabled = false;
                StatusLabel.Text = "Searching...";

                List<Comic> comics = await _lookupService.GetComicsByUPCAsync(normalizedUPC);

                // if nothing is found
                if (comics.Count == 0)
                {
                    StatusLabel.Text = "No comic was found with that UPC";
                    ClearComicFields();
                    return;
                }

                Comic? comic;

                // only one comic found
                if (comics.Count == 1)
                {
                    comic = comics[0];
                }
                else
                {
                    // multiple comics found
                    using ComicSelectionForm selectionForm = new ComicSelectionForm(comics);

                    if (selectionForm.ShowDialog() != DialogResult.OK)
                    {
                        StatusLabel.Text = "Comic selection cancelled";
                        return;
                    }

                    comic = selectionForm.SelectedComic;
                }

                // No comic was selected
                if (comic == null)
                {
                    StatusLabel.Text = "No comic was selected.";
                    ClearComicFields();
                    return;
                }

                // display comic info
                TitleTextBox.Text = comic.Title;
                IssueTextBox.Text = comic.IssueNumber;
                PublisherTextBox.Text = comic.Publisher;
                ReleaseYearTextBox.Text = comic.ReleaseYear?.ToString() ?? "";
                // store cover url
                _gcdCoverURL = comic.CoverPath;

                // enable fields for editing
                SetComicFieldsEnabled(true);

                StatusLabel.Text = "Comic found. You can edit the information before adding it.";
            }
            // error handling
            catch (HttpRequestException)
            {
                ClearComicFields();

                StatusLabel.Text = "Unable to connect to the Grand Comics Database";
            }
            catch (Exception)
            {
                ClearComicFields();
                StatusLabel.Text = "An unexpected error occured.";
            }
            finally
            {
                // re-enable button after search is concluded
                SearchUPCButton.Enabled = true;
            }
        }

        private void ClearUPCButton_Click(object sender, EventArgs e)
        {
            UPCTextBox.Clear();

            ClearComicFields();

            StatusLabel.Text = "";

            UPCTextBox.Focus();
        }

        private async void AddComicUPCButton_Click(object sender, EventArgs e)
        {
            // Make sure required fields have been entered
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                StatusLabel.Text = "Please search for a comic before adding it";
                return;
            }

            if (string.IsNullOrWhiteSpace(IssueTextBox.Text))
            {
                StatusLabel.Text = "Please enter an issue number";
                return;
            }
            if (string.IsNullOrWhiteSpace(PublisherTextBox.Text))
            {
                StatusLabel.Text = "Please enter a publisher";
                return;
            }

            // Release Year validation
            string releaseYearText = ReleaseYearTextBox.Text.Trim();

            int? releaseYear = null;

            if (!string.IsNullOrWhiteSpace(releaseYearText))
            {
                if (!int.TryParse(releaseYearText, out int parsedYear) || parsedYear < 1000 || parsedYear > DateTime.Now.Year + 5)
                {
                    StatusLabel.Text = "Please enter a valid release year.";
                    ReleaseYearTextBox.Focus();
                    return;
                }

                releaseYear = parsedYear;
            }

            // Create comic object
            Comic comic = new Comic
            {
                Title = TitleTextBox.Text,
                IssueNumber = IssueTextBox.Text,
                Publisher = PublisherTextBox.Text,
                ReleaseYear = releaseYear,
                UPC = string.IsNullOrWhiteSpace(UPCTextBox.Text)
                    ? null
                    : UPCTextBox.Text.Trim(),
            };

            try
            {
                AddComicUPCButton.Enabled = false;
                StatusLabel.Text = "Adding comic...";

                Database database = new Database();

                // Add comic and get it's new assigned local ID
                int comicId = database.AddComic(comic);

                bool coverSaved = false;

                // Try to download GCD cover if one is available
                if (!string.IsNullOrWhiteSpace(_gcdCoverURL))
                {
                    try
                    {
                        string coverPath =
                            await _coverService.DownloadCoverAsync(
                                _gcdCoverURL,
                                comicId
                            );

                        database.UpdateCoverPath(
                            comicId,
                            coverPath
                        );

                        coverSaved = true;
                    }
                    catch { 
                            // comic already saved, cover failure is no big deal
                    }
                }

                if (coverSaved)
                {
                    StatusLabel.Text = $"{comic.Title} #{comic.IssueNumber} has been successfully added.";
                }
                else
                {
                    StatusLabel.Text = $"{comic.Title} #{comic.IssueNumber} has been successfully added, but no cover was available.";
                }

                // Clear comic information so user can add new comic
                ClearComicFields();

                // Keep UPC box ready for next entry
                UPCTextBox.Clear();
                UPCTextBox.Focus();
            }
            // error handling
            catch (Exception)
            {
                StatusLabel.Text = "An error occured while adding the comic.";
            }
            finally
            {
                AddComicUPCButton.Enabled = false;
            }
        }

        private void CancelUPCButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetComicFieldsEnabled(bool enabled)
        {
            TitleTextBox.Enabled = enabled;
            IssueTextBox.Enabled = enabled;
            PublisherTextBox.Enabled = enabled;
            ReleaseYearTextBox.Enabled = enabled;
            AddComicUPCButton.Enabled = enabled;
        }

        // -- Styling --

        private void StyleResultTextBox(TextBox textBox)
        {
            textBox.BackColor = Theme.Background;
            textBox.BorderStyle = BorderStyle.None;
            textBox.ForeColor = Theme.Text;
        }

        private void StyleButtons()
        {
            UIHelper.StyleButton(AddComicUPCButton);
            UIHelper.StyleButton(SearchUPCButton);
            UIHelper.StyleButton(CancelUPCButton);
            AddComicUPCButton.FlatAppearance.BorderColor = AddComicUPCButton.BackColor;
            UIHelper.StyleButton(ClearUPCButton);
        }

        private void StyleTextBoxes()
        {
            UPCTextBox.BorderStyle = BorderStyle.FixedSingle;
            UPCTextBox.BackColor = Theme.Button;
            UPCTextBox.ForeColor = Theme.Text;
            StyleResultTextBox(TitleTextBox);
            StyleResultTextBox(IssueTextBox);
            StyleResultTextBox(PublisherTextBox);
            StyleResultTextBox(ReleaseYearTextBox);
        }

        private void ApplyTheme()
        {
            StyleButtons();
            UIHelper.StyleForm(this);
            StyleTextBoxes();
        }


        // TEST BUTTON
        private async void TestCoverButton_Click(object sender, EventArgs e)
        {
            string coverUrl =
                "https://files1.comics.org//img/gcd/covers_by_id/1835/w400/1835446.jpg";

            try
            {
                StatusLabel.Text = "Downloading cover...";

                string coverPath =
                    await _coverService.DownloadCoverAsync(
                        coverUrl,
                        999999
                    );

                StatusLabel.Text =
                    $"Cover saved successfully: {coverPath}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Cover Download Error"
                );

                StatusLabel.Text =
                    "Unable to download cover.";
            }
        }
    }
}
