using ComicCollection.Helpers;
using ComicCollection.Styles;
using ComicCollection.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ComicCollection.Forms
{
    public partial class ComicSelectionForm : Form
    {

        private List<Comic> _comics;

        public Comic? SelectedComic { get; private set; }
        public ComicSelectionForm(List<Comic> comics)
        {
            InitializeComponent();

            ApplyTheme();

            _comics = comics;

            LoadComics();
        }

        private void LoadComics()
        {
            SelectionDataGridView.Rows.Clear();

            foreach (Comic comic in _comics)
            {
                SelectionDataGridView.Rows.Add
                    (
                        comic.Title,
                        comic.IssueNumber,
                        comic.Publisher,
                        comic.ReleaseYear
                    );
            }
        }

        private void ExitSelectionButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void SelectionDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <0)
            {
                return;
            }

            SelectedComic = _comics[e.RowIndex];

            DialogResult = DialogResult.OK;
        }




        // STYLING

        private void StyleDataGridView()
        {
            SelectionDataGridView.BackgroundColor = Theme.Background;
            SelectionDataGridView.GridColor = Theme.Input;

            // Cells
            SelectionDataGridView.DefaultCellStyle.BackColor = Theme.Input;
            SelectionDataGridView.DefaultCellStyle.ForeColor = Theme.Text;

            SelectionDataGridView.DefaultCellStyle.SelectionBackColor = Theme.Selection;
            SelectionDataGridView.DefaultCellStyle.SelectionForeColor = Theme.Text;

            // Column headers
            SelectionDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Theme.Panel;
            SelectionDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Theme.Text;

            SelectionDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme.Panel;
            SelectionDataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = Theme.Text;

            SelectionDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(SelectionDataGridView.Font, FontStyle.Bold);

            // Size and appearance
            SelectionDataGridView.ColumnHeadersHeight = 30;
            SelectionDataGridView.RowTemplate.Height = 50;
            SelectionDataGridView.RowHeadersVisible = false;
            SelectionDataGridView.EnableHeadersVisualStyles = false;
            SelectionDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void ApplyTheme()
        {
            UIHelper.StyleForm(this);
            StyleDataGridView();
            UIHelper.StyleButton(ExitSelectionButton);
        }

    }
}
