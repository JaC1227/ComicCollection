using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms.VisualStyles;
using ComicCollection.Data;
using ComicCollection.Forms;
using ComicCollection.Helpers;
using ComicCollection.Models;
using ComicCollection.Services;
using ComicCollection.Styles;
using SQLitePCL;

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


        // image loading helper
        private Image? LoadCoverImage(string? coverPath)
        {
            if (string.IsNullOrWhiteSpace(coverPath))
            {
                return null;
            }

            string fullPath = Path.Combine(AppContext.BaseDirectory, coverPath);

            if (!File.Exists(fullPath))
            {
                return null;
            }

            try
            {
                using Image original = Image.FromFile(fullPath);

                return new Bitmap(original);
            }
            catch
            {
                return null;
            }
        }

        // Update DataGrid to Load Comics from Database
        private void LoadComics(string search = "")
        {
            Database database = new Database();

            List<Comic> comics = database.GetComics(search);

            ComicDataGridView.Rows.Clear();

            foreach (Comic comic in comics)
            {
                Image? cover = LoadCoverImage(comic.CoverPath);

                if (comic.CoverPath != null)
                {
                    Console.WriteLine(
                        $"CoverPath: {comic.CoverPath}"
                    );
                }

                ComicDataGridView.Rows.Add(
                    comic.Id,
                    cover,
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

        // for showing comic image in picture box
        private void ComicDataGridView_SelectionChanged(
            object sender, EventArgs e)
        {
            // clear current cover
            ComicCoverPictureBox.Image = null;

            if (ComicDataGridView.CurrentRow == null)
            {
                return;
            }

            object? idValue = ComicDataGridView.CurrentRow.Cells["IdColumn"].Value;

            if (idValue == null)
            {
                return;
            }

            int comicId = Convert.ToInt32(idValue);

            Database database = new Database();

            Comic? comic = database.GetComic(comicId);

            if (comic == null)
            {
                return;
            }

            ComicCoverPictureBox.Image = LoadCoverImage(comic.CoverPath);
        }


        // Changing the image
        private void ComicDataGridView_CellDoubleClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            // Ignore header double-clicks
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            // Only allow double-clicking the cover column
            if (ComicDataGridView.Columns[e.ColumnIndex].Name != "CoverColumn")
            {
                return;
            }

            object? idValue =
                ComicDataGridView.Rows[e.RowIndex]
                    .Cells["IdColumn"].Value;

            if (idValue == null)
            {
                return;
            }

            int comicId = Convert.ToInt32(idValue);

            using OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Choose Comic Cover";
            dialog.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                string coversDirectory = Path.Combine(
                    AppContext.BaseDirectory,
                    "Covers"
                );

                Directory.CreateDirectory(coversDirectory);

                string destinationPath = Path.Combine(
                    coversDirectory,
                    $"{comicId}.jpg"
                );

                // Load the selected image and save it as JPEG
                using Image image = Image.FromFile(dialog.FileName);

                image.Save(
                    destinationPath,
                    System.Drawing.Imaging.ImageFormat.Jpeg
                );

                string coverPath = Path.Combine(
                    "Covers",
                    $"{comicId}.jpg"
                );

                Database database = new Database();

                database.UpdateCoverPath(
                    comicId,
                    coverPath
                );

                // Reload the catalogue so the thumbnail updates
                LoadComics();

                // Reselect the comic
                foreach (DataGridViewRow row in ComicDataGridView.Rows)
                {
                    if (Convert.ToInt32(
                        row.Cells["IdColumn"].Value
                    ) == comicId)
                    {
                        row.Selected = true;
                        ComicDataGridView.CurrentCell =
                            row.Cells["CoverColumn"];

                        break;
                    }
                }

                MessageBox.Show(
                    "Cover updated successfully.",
                    "Cover Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to add the selected cover.",
                    "Cover Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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
            ComicDataGridView.RowTemplate.Height = 80;
            ComicDataGridView.RowHeadersVisible = false;
            ComicDataGridView.EnableHeadersVisualStyles = false;
            ComicDataGridView.Columns["CoverColumn"].DefaultCellStyle.NullValue = null;
            ComicDataGridView.Columns["CoverColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ComicDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            ComicDataGridView.Columns["CoverColumn"].DefaultCellStyle.Padding = new Padding(0, 2, 0, 2);
        }

        // Put it all together...
        private void ApplyTheme()
        {
            UIHelper.StyleForm(this);
            StyleButtons();
            StyleDataGridView();
        }




        // add comic via upc button
        private void AddComicUPC_Click(object sender, EventArgs e)
        {
            UPCLookupForm lookupForm = new UPCLookupForm();

            lookupForm.ShowDialog();

            LoadComics();
        }

        private void BarcodeScannerButton_Click(object sender, EventArgs e)
        {
            using BarcodeScannerForm form = new BarcodeScannerForm();

            form.ShowDialog();

            LoadComics();
        }
    }
}
