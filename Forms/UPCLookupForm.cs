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

namespace ComicCollection.Forms
{
    public partial class UPCLookupForm : Form
    {
        private readonly ComicLookupService _lookupService;
        public UPCLookupForm()
        {
            InitializeComponent();

            ApplyTheme();

            // start with comic info fields disabled
            SetComicFieldsEnabled(false);

            _lookupService = new ComicLookupService();

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

                Comic? comic = await _lookupService.GetComicByUPCAsync(normalizedUPC);

                // if nothing is found
                if (comic == null)
                {
                    StatusLabel.Text = "No comic was found with that UPC";
                    ClearComicFields();
                    return;
                }

                TitleTextBox.Text = comic.Title;
                IssueTextBox.Text = comic.IssueNumber;
                PublisherTextBox.Text = comic.Publisher;
                ReleaseYearTextBox.Text = comic.ReleaseYear?.ToString() ?? "";

                // enable fields for editing
                SetComicFieldsEnabled(true);

                StatusLabel.Text = "Comic found. You can edit the information before adding it.";
            }
            // error handling
            catch (InvalidOperationException)
            {
                ClearComicFields();

                StatusLabel.Text = "This UPC matches multiple comics and cannot be automatically added.";
            }
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

        private void AddComicUPCButton_Click(object sender, EventArgs e)
        {
            // Make sure required fields have been entered
            if (string.IsNullOrEmpty(TitleTextBox.Text))
            {
                StatusLabel.Text = "Please search for a comic before adding it";
                return;
            }

            if (string.IsNullOrEmpty(IssueTextBox.Text))
            {
                StatusLabel.Text = "Please enter an issue number";
                return;
            }
            if (string.IsNullOrEmpty(PublisherTextBox.Text))
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
            }

            // Create comic object
            Comic comic = new Comic
            {
                Title = TitleTextBox.Text,
                IssueNumber = IssueTextBox.Text,
                Publisher = PublisherTextBox.Text,
                ReleaseYear = int.TryParse(
                    ReleaseYearTextBox.Text.Trim(),
                    out int year
                ) ? year : null,

                UPC = string.IsNullOrWhiteSpace(UPCTextBox.Text)
                    ? null
                    : UPCTextBox.Text.Trim()
            };

            try
            {
                Database database = new Database();

                database.AddComic(comic);

                // Tell user what was added
                StatusLabel.Text = $"{comic.Title} #{comic.IssueNumber} has been successfully added.";

                // Clear comic information so user can add new comic
                ClearComicFields();

                // Keep UPC box ready for next entry
                UPCTextBox.Clear();
                UPCTextBox.Focus();
            }
            catch (Exception)
            {
                StatusLabel.Text = "An error occured while adding the comic";
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

    }
}
