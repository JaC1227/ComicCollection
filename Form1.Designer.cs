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
            TestGCDButton = new Button();
            AddComicUPC = new Button();
            ((System.ComponentModel.ISupportInitialize)ComicDataGridView).BeginInit();
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
            ComicDataGridView.Columns.AddRange(new DataGridViewColumn[] { IdColumn, TitleColumn, IssueColumn, PublisherColumn, YearColumn });
            ComicDataGridView.Location = new Point(31, 133);
            ComicDataGridView.Margin = new Padding(4, 3, 4, 3);
            ComicDataGridView.MultiSelect = false;
            ComicDataGridView.Name = "ComicDataGridView";
            ComicDataGridView.ReadOnly = true;
            ComicDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ComicDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ComicDataGridView.Size = new Size(521, 349);
            ComicDataGridView.TabIndex = 0;
            // 
            // IdColumn
            // 
            IdColumn.HeaderText = "Id";
            IdColumn.Name = "IdColumn";
            IdColumn.ReadOnly = true;
            IdColumn.Visible = false;
            // 
            // TitleColumn
            // 
            TitleColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TitleColumn.HeaderText = "    TITLE";
            TitleColumn.MinimumWidth = 100;
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
            AddComicButton.Anchor = AnchorStyles.Top;
            AddComicButton.Location = new Point(168, 40);
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
            SearchTextBox.Location = new Point(31, 104);
            SearchTextBox.Margin = new Padding(4, 3, 4, 3);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(274, 22);
            SearchTextBox.TabIndex = 2;
            // 
            // ComicCountLabel
            // 
            ComicCountLabel.Anchor = AnchorStyles.Bottom;
            ComicCountLabel.AutoSize = true;
            ComicCountLabel.Location = new Point(248, 485);
            ComicCountLabel.Margin = new Padding(4, 0, 4, 0);
            ComicCountLabel.Name = "ComicCountLabel";
            ComicCountLabel.Size = new Size(93, 17);
            ComicCountLabel.TabIndex = 4;
            ComicCountLabel.Text = "Total Comics: 0";
            // 
            // DeleteComicButton
            // 
            DeleteComicButton.Anchor = AnchorStyles.Top;
            DeleteComicButton.Location = new Point(313, 72);
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
            SearchButton.Location = new Point(313, 104);
            SearchButton.Margin = new Padding(4, 3, 4, 3);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(140, 24);
            SearchButton.TabIndex = 6;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // ClearSearchButton
            // 
            ClearSearchButton.Anchor = AnchorStyles.Top;
            ClearSearchButton.Location = new Point(461, 104);
            ClearSearchButton.Margin = new Padding(4, 3, 4, 3);
            ClearSearchButton.Name = "ClearSearchButton";
            ClearSearchButton.Size = new Size(91, 24);
            ClearSearchButton.TabIndex = 7;
            ClearSearchButton.Text = "Clear";
            ClearSearchButton.UseVisualStyleBackColor = true;
            ClearSearchButton.Click += ClearSearchButton_Click;
            // 
            // TestGCDButton
            // 
            TestGCDButton.Location = new Point(12, 12);
            TestGCDButton.Name = "TestGCDButton";
            TestGCDButton.Size = new Size(75, 23);
            TestGCDButton.TabIndex = 8;
            TestGCDButton.Text = "Test GCD";
            TestGCDButton.UseVisualStyleBackColor = true;
            TestGCDButton.Click += TestGCDButton_Click;
            // 
            // AddComicUPC
            // 
            AddComicUPC.Anchor = AnchorStyles.Top;
            AddComicUPC.Location = new Point(168, 72);
            AddComicUPC.Margin = new Padding(4, 3, 4, 3);
            AddComicUPC.Name = "AddComicUPC";
            AddComicUPC.Size = new Size(122, 26);
            AddComicUPC.TabIndex = 9;
            AddComicUPC.Text = "Add Comic by UPC";
            AddComicUPC.UseVisualStyleBackColor = true;
            AddComicUPC.Click += AddComicUPC_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 511);
            Controls.Add(AddComicUPC);
            Controls.Add(TestGCDButton);
            Controls.Add(ClearSearchButton);
            Controls.Add(SearchButton);
            Controls.Add(DeleteComicButton);
            Controls.Add(ComicCountLabel);
            Controls.Add(SearchTextBox);
            Controls.Add(AddComicButton);
            Controls.Add(ComicDataGridView);
            Font = new Font("Franklin Gothic Medium", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(600, 550);
            Name = "Form1";
            Text = "Comic Collection";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)ComicDataGridView).EndInit();
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
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewTextBoxColumn TitleColumn;
        private DataGridViewTextBoxColumn IssueColumn;
        private DataGridViewTextBoxColumn PublisherColumn;
        private DataGridViewTextBoxColumn YearColumn;
        private Button TestGCDButton;
        private Button AddComicUPC;
    }
}
