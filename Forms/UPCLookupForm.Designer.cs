namespace ComicCollection.Forms
{
    partial class UPCLookupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UPCLabel = new Label();
            UPCTextBox = new TextBox();
            SearchUPCButton = new Button();
            CancelUPCButton = new Button();
            AddComicUPCButton = new Button();
            TitleLabel = new Label();
            IssueLabel = new Label();
            label3 = new Label();
            ReleaseYearLabel = new Label();
            TitleTextBox = new TextBox();
            IssueTextBox = new TextBox();
            PublisherTextBox = new TextBox();
            ReleaseYearTextBox = new TextBox();
            StatusLabel = new Label();
            ClearUPCButton = new Button();
            TestCoverButton = new Button();
            SuspendLayout();
            // 
            // UPCLabel
            // 
            UPCLabel.Anchor = AnchorStyles.Top;
            UPCLabel.AutoSize = true;
            UPCLabel.Location = new Point(157, 21);
            UPCLabel.Name = "UPCLabel";
            UPCLabel.Size = new Size(109, 15);
            UPCLabel.TabIndex = 0;
            UPCLabel.Text = "Add Comic by UPC";
            // 
            // UPCTextBox
            // 
            UPCTextBox.Anchor = AnchorStyles.Top;
            UPCTextBox.Location = new Point(126, 39);
            UPCTextBox.Name = "UPCTextBox";
            UPCTextBox.Size = new Size(183, 23);
            UPCTextBox.TabIndex = 1;
            // 
            // SearchUPCButton
            // 
            SearchUPCButton.Anchor = AnchorStyles.Top;
            SearchUPCButton.Location = new Point(155, 68);
            SearchUPCButton.Name = "SearchUPCButton";
            SearchUPCButton.Size = new Size(111, 23);
            SearchUPCButton.TabIndex = 2;
            SearchUPCButton.Text = "Search UPC";
            SearchUPCButton.UseVisualStyleBackColor = true;
            SearchUPCButton.Click += SearchUPCButton_Click;
            // 
            // CancelUPCButton
            // 
            CancelUPCButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelUPCButton.Location = new Point(369, 380);
            CancelUPCButton.Name = "CancelUPCButton";
            CancelUPCButton.Size = new Size(47, 23);
            CancelUPCButton.TabIndex = 3;
            CancelUPCButton.Text = "Exit";
            CancelUPCButton.UseVisualStyleBackColor = true;
            CancelUPCButton.Click += CancelUPCButton_Click;
            // 
            // AddComicUPCButton
            // 
            AddComicUPCButton.Anchor = AnchorStyles.Bottom;
            AddComicUPCButton.Location = new Point(164, 380);
            AddComicUPCButton.Name = "AddComicUPCButton";
            AddComicUPCButton.Size = new Size(102, 23);
            AddComicUPCButton.TabIndex = 4;
            AddComicUPCButton.Text = "Add Comic";
            AddComicUPCButton.UseVisualStyleBackColor = true;
            AddComicUPCButton.Click += AddComicUPCButton_Click;
            // 
            // TitleLabel
            // 
            TitleLabel.Anchor = AnchorStyles.Top;
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(120, 107);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(33, 15);
            TitleLabel.TabIndex = 5;
            TitleLabel.Text = "Title:";
            // 
            // IssueLabel
            // 
            IssueLabel.Anchor = AnchorStyles.Top;
            IssueLabel.AutoSize = true;
            IssueLabel.Location = new Point(120, 137);
            IssueLabel.Name = "IssueLabel";
            IssueLabel.Size = new Size(36, 15);
            IssueLabel.TabIndex = 6;
            IssueLabel.Text = "Issue:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(99, 168);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 7;
            label3.Text = "Publisher:";
            // 
            // ReleaseYearLabel
            // 
            ReleaseYearLabel.Anchor = AnchorStyles.Top;
            ReleaseYearLabel.AutoSize = true;
            ReleaseYearLabel.Location = new Point(126, 198);
            ReleaseYearLabel.Name = "ReleaseYearLabel";
            ReleaseYearLabel.Size = new Size(32, 15);
            ReleaseYearLabel.TabIndex = 8;
            ReleaseYearLabel.Text = "Year:";
            // 
            // TitleTextBox
            // 
            TitleTextBox.Anchor = AnchorStyles.Top;
            TitleTextBox.Location = new Point(164, 104);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(155, 23);
            TitleTextBox.TabIndex = 9;
            // 
            // IssueTextBox
            // 
            IssueTextBox.Anchor = AnchorStyles.Top;
            IssueTextBox.Location = new Point(164, 133);
            IssueTextBox.Name = "IssueTextBox";
            IssueTextBox.Size = new Size(155, 23);
            IssueTextBox.TabIndex = 10;
            // 
            // PublisherTextBox
            // 
            PublisherTextBox.Anchor = AnchorStyles.Top;
            PublisherTextBox.Location = new Point(164, 165);
            PublisherTextBox.Name = "PublisherTextBox";
            PublisherTextBox.Size = new Size(155, 23);
            PublisherTextBox.TabIndex = 11;
            // 
            // ReleaseYearTextBox
            // 
            ReleaseYearTextBox.Anchor = AnchorStyles.Top;
            ReleaseYearTextBox.Location = new Point(164, 195);
            ReleaseYearTextBox.Name = "ReleaseYearTextBox";
            ReleaseYearTextBox.Size = new Size(155, 23);
            ReleaseYearTextBox.TabIndex = 12;
            // 
            // StatusLabel
            // 
            StatusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatusLabel.Location = new Point(2, 410);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(423, 22);
            StatusLabel.TabIndex = 13;
            StatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ClearUPCButton
            // 
            ClearUPCButton.Anchor = AnchorStyles.Top;
            ClearUPCButton.Location = new Point(272, 68);
            ClearUPCButton.Name = "ClearUPCButton";
            ClearUPCButton.Size = new Size(47, 23);
            ClearUPCButton.TabIndex = 14;
            ClearUPCButton.Text = "Clear";
            ClearUPCButton.UseVisualStyleBackColor = true;
            ClearUPCButton.Click += ClearUPCButton_Click;
            // 
            // TestCoverButton
            // 
            TestCoverButton.Location = new Point(155, 271);
            TestCoverButton.Name = "TestCoverButton";
            TestCoverButton.Size = new Size(150, 23);
            TestCoverButton.TabIndex = 15;
            TestCoverButton.Text = "Test Cover Browser";
            TestCoverButton.UseVisualStyleBackColor = true;
            TestCoverButton.Click += TestCoverButton_Click;
            // 
            // UPCLookupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 431);
            Controls.Add(TestCoverButton);
            Controls.Add(ClearUPCButton);
            Controls.Add(StatusLabel);
            Controls.Add(ReleaseYearTextBox);
            Controls.Add(PublisherTextBox);
            Controls.Add(IssueTextBox);
            Controls.Add(TitleTextBox);
            Controls.Add(ReleaseYearLabel);
            Controls.Add(label3);
            Controls.Add(IssueLabel);
            Controls.Add(TitleLabel);
            Controls.Add(AddComicUPCButton);
            Controls.Add(CancelUPCButton);
            Controls.Add(SearchUPCButton);
            Controls.Add(UPCTextBox);
            Controls.Add(UPCLabel);
            MinimumSize = new Size(250, 325);
            Name = "UPCLookupForm";
            Text = "UPC Lookup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UPCLabel;
        private TextBox UPCTextBox;
        private Button SearchUPCButton;
        private Button CancelUPCButton;
        private Button AddComicUPCButton;
        private Label TitleLabel;
        private Label IssueLabel;
        private Label label3;
        private Label ReleaseYearLabel;
        private TextBox TitleTextBox;
        private TextBox IssueTextBox;
        private TextBox PublisherTextBox;
        private TextBox ReleaseYearTextBox;
        private Label StatusLabel;
        private Button ClearUPCButton;
        private Button TestCoverButton;
    }
}