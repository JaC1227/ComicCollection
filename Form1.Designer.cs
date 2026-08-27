namespace ComicCollection
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            ComicDataGridView = new DataGridView();
            IdColumn = new DataGridViewTextBoxColumn();
            CoverColumn = new DataGridViewImageColumn();
            TitleColumn = new DataGridViewTextBoxColumn();
            IssueColumn = new DataGridViewTextBoxColumn();
            PublisherColumn = new DataGridViewTextBoxColumn();
            YearColumn = new DataGridViewTextBoxColumn();
            AddComicButton = new Button();
            SearchTextBox = new TextBox();
            ComicCountLabel = new Label();
            DeleteComicButton = new Button();
            SearchButton = new Button();
            ClearSearchButton = new Button();
            AddComicUPC = new Button();
            ComicCoverPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ComicDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ComicCoverPictureBox).BeginInit();
            SuspendLayout();
            // 
            // ComicDataGridView
            // 
            ComicDataGridView.AllowUserToAddRows = false;
            ComicDataGridView.AllowUserToDeleteRows = false;
            ComicDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ComicDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Franklin Gothic Medium", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ComicDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ComicDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ComicDataGridView.Columns.AddRange(new DataGridViewColumn[] { IdColumn, CoverColumn, TitleColumn, IssueColumn, PublisherColumn, YearColumn });
            ComicDataGridView.Location = new Point(239, 134);
            ComicDataGridView.Margin = new Padding(4, 3, 4, 3);
            ComicDataGridView.MultiSelect = false;
            ComicDataGridView.Name = "ComicDataGridView";
            ComicDataGridView.ReadOnly = true;
            ComicDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ComicDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ComicDataGridView.Size = new Size(566, 373);
            ComicDataGridView.TabIndex = 0;
            ComicDataGridView.CellDoubleClick += ComicDataGridView_CellDoubleClick;
            ComicDataGridView.SelectionChanged += ComicDataGridView_SelectionChanged;
            // 
            // IdColumn
            // 
            IdColumn.HeaderText = "Id";
            IdColumn.Name = "IdColumn";
            IdColumn.ReadOnly = true;
            IdColumn.Visible = false;
            // 
            // CoverColumn
            // 
            CoverColumn.FillWeight = 50F;
            CoverColumn.HeaderText = "COVER        ";
            CoverColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            CoverColumn.MinimumWidth = 50;
            CoverColumn.Name = "CoverColumn";
            CoverColumn.ReadOnly = true;
            CoverColumn.Width = 72;
            // 
            // TitleColumn
            // 
            TitleColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TitleColumn.HeaderText = "    TITLE";
            TitleColumn.MinimumWidth = 130;
            TitleColumn.Name = "TitleColumn";
            TitleColumn.ReadOnly = true;
            // 
            // IssueColumn
            // 
            IssueColumn.HeaderText = "    ISSUE";
            IssueColumn.MinimumWidth = 10;
            IssueColumn.Name = "IssueColumn";
            IssueColumn.ReadOnly = true;
            IssueColumn.Width = 86;
            // 
            // PublisherColumn
            // 
            PublisherColumn.HeaderText = "    PUBLISHER";
            PublisherColumn.Name = "PublisherColumn";
            PublisherColumn.ReadOnly = true;
            PublisherColumn.Width = 130;
            // 
            // YearColumn
            // 
            YearColumn.HeaderText = "    YEAR";
            YearColumn.Name = "YearColumn";
            YearColumn.ReadOnly = true;
            YearColumn.Width = 90;
            // 
            // AddComicButton
            // 
            AddComicButton.Location = new Point(45, 12);
            AddComicButton.Margin = new Padding(4, 3, 4, 3);
            AddComicButton.Name = "AddComicButton";
            AddComicButton.Size = new Size(122, 26);
            AddComicButton.TabIndex = 1;
            AddComicButton.Text = "Add Comic";
            AddComicButton.UseVisualStyleBackColor = true;
            AddComicButton.Click += AddComicButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Anchor = AnchorStyles.Top;
            SearchTextBox.Location = new Point(300, 75);
            SearchTextBox.Margin = new Padding(4, 3, 4, 3);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(431, 22);
            SearchTextBox.TabIndex = 2;
            // 
            // ComicCountLabel
            // 
            ComicCountLabel.Anchor = AnchorStyles.Bottom;
            ComicCountLabel.AutoSize = true;
            ComicCountLabel.Location = new Point(469, 510);
            ComicCountLabel.Margin = new Padding(4, 0, 4, 0);
            ComicCountLabel.Name = "ComicCountLabel";
            ComicCountLabel.Size = new Size(93, 17);
            ComicCountLabel.TabIndex = 4;
            ComicCountLabel.Text = "Total Comics: 0";
            // 
            // DeleteComicButton
            // 
            DeleteComicButton.Location = new Point(45, 103);
            DeleteComicButton.Margin = new Padding(4, 3, 4, 3);
            DeleteComicButton.Name = "DeleteComicButton";
            DeleteComicButton.Size = new Size(122, 26);
            DeleteComicButton.TabIndex = 5;
            DeleteComicButton.Text = "Remove Comic";
            DeleteComicButton.UseVisualStyleBackColor = true;
            DeleteComicButton.Click += DeleteComicButton_Click;
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Top;
            SearchButton.Location = new Point(300, 103);
            SearchButton.Margin = new Padding(4, 3, 4, 3);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(309, 24);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // ClearSearchButton
            // 
            ClearSearchButton.Anchor = AnchorStyles.Top;
            ClearSearchButton.Location = new Point(627, 103);
            ClearSearchButton.Margin = new Padding(4, 3, 4, 3);
            ClearSearchButton.Name = "ClearSearchButton";
            ClearSearchButton.Size = new Size(104, 24);
            ClearSearchButton.TabIndex = 7;
            ClearSearchButton.Text = "Clear";
            ClearSearchButton.UseVisualStyleBackColor = true;
            ClearSearchButton.Click += ClearSearchButton_Click;
            // 
            // AddComicUPC
            // 
            AddComicUPC.Location = new Point(45, 44);
            AddComicUPC.Margin = new Padding(4, 3, 4, 3);
            AddComicUPC.Name = "AddComicUPC";
            AddComicUPC.Size = new Size(122, 26);
            AddComicUPC.TabIndex = 9;
            AddComicUPC.Text = "Add Comic by UPC";
            AddComicUPC.UseVisualStyleBackColor = true;
            AddComicUPC.Click += AddComicUPC_Click;
            // 
            // ComicCoverPictureBox
            // 
            ComicCoverPictureBox.Location = new Point(12, 152);
            ComicCoverPictureBox.Name = "ComicCoverPictureBox";
            ComicCoverPictureBox.Size = new Size(220, 355);
            ComicCoverPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            ComicCoverPictureBox.TabIndex = 10;
            ComicCoverPictureBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 536);
            Controls.Add(ComicCoverPictureBox);
            Controls.Add(AddComicUPC);
            Controls.Add(ClearSearchButton);
            Controls.Add(SearchButton);
            Controls.Add(DeleteComicButton);
            Controls.Add(ComicCountLabel);
            Controls.Add(SearchTextBox);
            Controls.Add(AddComicButton);
            Controls.Add(ComicDataGridView);
            Font = new Font("Franklin Gothic Medium", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(853, 575);
            Name = "Form1";
            Text = "Comic Collection";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)ComicDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ComicCoverPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ComicDataGridView;
        private Button AddComicButton;
        private TextBox SearchTextBox;
        private Label ComicCountLabel;
        private Button DeleteComicButton;
        private Button SearchButton;
        private Button ClearSearchButton;
        private Button AddComicUPC;
        private PictureBox ComicCoverPictureBox;
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewImageColumn CoverColumn;
        private DataGridViewTextBoxColumn TitleColumn;
        private DataGridViewTextBoxColumn IssueColumn;
        private DataGridViewTextBoxColumn PublisherColumn;
        private DataGridViewTextBoxColumn YearColumn;
    }
}
