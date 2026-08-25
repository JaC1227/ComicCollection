namespace ComicCollection
{
    partial class AddComicForm
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
            SaveButton = new Button();
            CancelButton = new Button();
            TitleLabel = new Label();
            IssueLabel = new Label();
            PublisherLabel = new Label();
            YearLabel = new Label();
            TitleTextBox = new TextBox();
            IssueTextBox = new TextBox();
            PublisherTextBox = new TextBox();
            YearTextBox = new TextBox();
            UPCLabel = new Label();
            UPCTextBox = new TextBox();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(111, 215);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 0;
            SaveButton.Text = "Add Comic";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(41, 215);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(61, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(44, 34);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(33, 15);
            TitleLabel.TabIndex = 2;
            TitleLabel.Text = "Title:";
            // 
            // IssueLabel
            // 
            IssueLabel.AutoSize = true;
            IssueLabel.Location = new Point(41, 65);
            IssueLabel.Name = "IssueLabel";
            IssueLabel.Size = new Size(36, 15);
            IssueLabel.TabIndex = 3;
            IssueLabel.Text = "Issue:";
            // 
            // PublisherLabel
            // 
            PublisherLabel.AutoSize = true;
            PublisherLabel.Location = new Point(18, 99);
            PublisherLabel.Name = "PublisherLabel";
            PublisherLabel.Size = new Size(59, 15);
            PublisherLabel.TabIndex = 4;
            PublisherLabel.Text = "Publisher:";
            // 
            // YearLabel
            // 
            YearLabel.AutoSize = true;
            YearLabel.Location = new Point(39, 130);
            YearLabel.Name = "YearLabel";
            YearLabel.Size = new Size(32, 15);
            YearLabel.TabIndex = 5;
            YearLabel.Text = "Year:";
            // 
            // TitleTextBox
            // 
            TitleTextBox.Location = new Point(86, 31);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(100, 23);
            TitleTextBox.TabIndex = 6;
            // 
            // IssueTextBox
            // 
            IssueTextBox.Location = new Point(86, 65);
            IssueTextBox.Name = "IssueTextBox";
            IssueTextBox.Size = new Size(100, 23);
            IssueTextBox.TabIndex = 7;
            // 
            // PublisherTextBox
            // 
            PublisherTextBox.Location = new Point(86, 96);
            PublisherTextBox.Name = "PublisherTextBox";
            PublisherTextBox.Size = new Size(100, 23);
            PublisherTextBox.TabIndex = 8;
            // 
            // YearTextBox
            // 
            YearTextBox.Location = new Point(86, 130);
            YearTextBox.Name = "YearTextBox";
            YearTextBox.Size = new Size(100, 23);
            YearTextBox.TabIndex = 9;
            // 
            // UPCLabel
            // 
            UPCLabel.AutoSize = true;
            UPCLabel.Location = new Point(41, 161);
            UPCLabel.Name = "UPCLabel";
            UPCLabel.Size = new Size(33, 15);
            UPCLabel.TabIndex = 10;
            UPCLabel.Text = "UPC:";
            // 
            // UPCTextBox
            // 
            UPCTextBox.Location = new Point(86, 161);
            UPCTextBox.Name = "UPCTextBox";
            UPCTextBox.Size = new Size(100, 23);
            UPCTextBox.TabIndex = 11;
            // 
            // AddComicForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(223, 250);
            Controls.Add(UPCTextBox);
            Controls.Add(UPCLabel);
            Controls.Add(YearTextBox);
            Controls.Add(PublisherTextBox);
            Controls.Add(IssueTextBox);
            Controls.Add(TitleTextBox);
            Controls.Add(YearLabel);
            Controls.Add(PublisherLabel);
            Controls.Add(IssueLabel);
            Controls.Add(TitleLabel);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Name = "AddComicForm";
            Text = "Add Comic";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveButton;
        private Button CancelButton;
        private Label TitleLabel;
        private Label IssueLabel;
        private Label PublisherLabel;
        private Label YearLabel;
        private TextBox TitleTextBox;
        private TextBox IssueTextBox;
        private TextBox PublisherTextBox;
        private TextBox YearTextBox;
        private Label UPCLabel;
        private TextBox UPCTextBox;
    }
}