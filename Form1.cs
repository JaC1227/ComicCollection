using ComicCollection.Data;
using ComicCollection.Models;
using ComicCollection.Services;
using ComicCollection.Styles;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using System.IO;
using ComicCollection.Forms;
using ComicCollection.Helpers;

namespace ComicCollection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ApplyTheme();
        }

        // Opens form to add comic manually
        private void AddComicButton_Click(object sender, EventArgs e)
        {
            AddComicForm form = new AddComicForm();

            form.ShowDialog();

            LoadComics();
        }

        // Update DataGrid to Load Comics from Database
        private void LoadComics(string search = "")
        {
            Database database = new Database();

            List<Comic> comics = database.GetComics(search);

            ComicDataGridView.Rows.Clear();

            foreach (Comic comic in comics)
            {
                ComicDataGridView.Rows.Add(
                    comic.Id,
                    comic.Title,
                    comic.IssueNumber,
                    comic.Publisher,
                    comic.ReleaseYear
                );
            }

            ComicCountLabel.Text = $"{comics.Count} comics";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComics();
        }

        // Delete Button Functionality
        private void DeleteComicButton_Click(object sender, EventArgs e)
        {
            if (ComicDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a comic to delete");
                return;
            }

            int id = Convert.ToInt32(
                ComicDataGridView.SelectedRows[0].Cells["IdColumn"].Value
                );
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this comic?",
                "Delete Comic",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes)
            {
                Database database = new Database();

                database.DeleteComic(id);

                LoadComics();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LoadComics(SearchTextBox.Text);
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            SearchTextBox.Clear();

            LoadComics();
        }

        // -- Colour & Design Theme --

        // Buttons

        private void StyleButtons()
        {
            UIHelper.StyleButton(AddComicButton);
            UIHelper.StyleButton(DeleteComicButton);
            UIHelper.StyleButton(SearchButton);
            UIHelper.StyleButton(ClearSearchButton);
            UIHelper.StyleButton(AddComicUPC);
            SearchTextBox.BackColor = Theme.Button;
            SearchTextBox.BorderStyle = BorderStyle.FixedSingle;
        }


        // DataGridView
        private void StyleDataGridView()
        {
            ComicDataGridView.BackgroundColor = Theme.Background;
            ComicDataGridView.GridColor = Theme.Input;

            // Cells
            ComicDataGridView.DefaultCellStyle.BackColor = Theme.Input;
            ComicDataGridView.DefaultCellStyle.ForeColor = Theme.Text;

            ComicDataGridView.DefaultCellStyle.SelectionBackColor = Theme.Selection;
            ComicDataGridView.DefaultCellStyle.SelectionForeColor = Theme.Text;

            // Column headers
            ComicDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Theme.Panel;
            ComicDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Theme.Text;

            ComicDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme.Panel;
            ComicDataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = Theme.Text;

            ComicDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(ComicDataGridView.Font, FontStyle.Bold);

            // Size and appearance
            ComicDataGridView.ColumnHeadersHeight = 35;
            ComicDataGridView.RowTemplate.Height = 30;
            ComicDataGridView.RowHeadersVisible = false;
            ComicDataGridView.EnableHeadersVisualStyles = false;
        }

        // Put it all together...
        private void ApplyTheme()
        {
            UIHelper.StyleForm(this);
            StyleButtons();
            StyleDataGridView();
        }
        

        // TEST BUTTON
        private async void TestGCDButton_Click(object sender, EventArgs e)
        {
            ComicLookupService lookupService = new ComicLookupService();

            try
            {
                Comic? comic = await lookupService.GetComicByUPCAsync(
                    "76194134373000011"
                );

                if (comic == null)
                {
                    MessageBox.Show("No comic was found with that UPC.");
                    return;
                }

                MessageBox.Show(
                    $"Title: {comic.Title}\n" +
                    $"Issue: {comic.IssueNumber}\n" +
                    $"Publisher: {comic.Publisher}\n" +
                    $"Year: {comic.ReleaseYear}\n" +
                    $"UPC: {comic.UPC}\n" +
                    $"Cover: {comic.CoverPath}"
                );
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Comic Lookup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (HttpRequestException)
            {
                MessageBox.Show(
                    "There was a problem connecting to the Grand Comics Database.",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // add comic via upc button
        private void AddComicUPC_Click(object sender, EventArgs e)
        {
            UPCLookupForm lookupForm = new UPCLookupForm();

            lookupForm.ShowDialog();

            LoadComics();
        }
    }
}
