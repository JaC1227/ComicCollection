using ComicCollection.Data;
using ComicCollection.Models;
using ComicCollection.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComicCollection.Helpers;

namespace ComicCollection
{
    public partial class AddComicForm : Form
    {
        public AddComicForm()
        {
            InitializeComponent();

            ApplyTheme();
        }

        // Clicking button to add a new comic
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // VALIDATION for entering new comics
            // Check title was entered
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                MessageBox.Show(
                    "Please enter a comic title (i.e. \"Amazing Fantasy\").",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );

                TitleTextBox.Focus();
                return;
            }

            // Check issue number was entered
            if (string.IsNullOrWhiteSpace(IssueTextBox.Text))
            {
                MessageBox.Show(
                    "Please enter an issue number.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );

                IssueTextBox.Focus();
                return;
            }

            // Check publisher was entered
            if (string.IsNullOrWhiteSpace(PublisherTextBox.Text))
            {
                MessageBox.Show(
                    "Please enter a publisher.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );

                TitleTextBox.Focus();
                return;
            }

            // Validate year if it was entered
            int? year = null;

            if (!string.IsNullOrWhiteSpace(YearTextBox.Text))
            {
                if (!int.TryParse(YearTextBox.Text, out int parsedYear))
                {
                    MessageBox.Show(
                        "Please enter a valid year.",
                        "Invalid Year",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                }
                if (parsedYear < 1000 || parsedYear > DateTime.Now.Year + 5)
                {
                    MessageBox.Show(
                        "Please enter a release year between 1000 & {DateTime.Now.Year}.",
                        "Invalid Year",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    YearTextBox.Focus();
                    return;
                }

                year = parsedYear;

            }

            // Create the comic object
            Comic comic = new Comic
            {
                Title = TitleTextBox.Text.Trim(),
                IssueNumber = IssueTextBox.Text.Trim(),
                Publisher = PublisherTextBox.Text.Trim(),
                ReleaseYear = year,
                UPC = UPCTextBox.Text.Trim()
            };

            // save comic
            Database database = new Database();

            database.AddComic(comic);

            MessageBox.Show(
                "Comic added successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // -- STYLING --
        // text boxes
        private void StyleTextBox(TextBox textBox)
        {
            textBox.BackColor = Theme.Button;
            textBox.BorderStyle = BorderStyle.None;
            textBox.ForeColor = Theme.Text;
        }
        private void StyleTextBoxes()
        {
            StyleTextBox(TitleTextBox);
            StyleTextBox(IssueTextBox);
            StyleTextBox(PublisherTextBox);
            StyleTextBox(YearTextBox);
            StyleTextBox(UPCTextBox);
        }
        //buttons
        private void StyleButtons()
        {
            UIHelper.StyleButton(SaveButton);
            UIHelper.StyleButton(CancelButton);
        }

        // all together
        private void ApplyTheme()
        {
            StyleTextBoxes();
            UIHelper.StyleForm(this);
            StyleButtons();
        }

    }
}
