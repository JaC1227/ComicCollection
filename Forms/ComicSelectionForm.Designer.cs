namespace ComicCollection.Forms
{
    partial class ComicSelectionForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            SelectionDataGridView = new DataGridView();
            SelectionTitleColumn = new DataGridViewTextBoxColumn();
            SelectionIssueColumn = new DataGridViewTextBoxColumn();
            SelectionPublisherColumn = new DataGridViewTextBoxColumn();
            SelectionYearColumn = new DataGridViewTextBoxColumn();
            ExitSelectionButton = new Button();
            ((System.ComponentModel.ISupportInitialize)SelectionDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Location = new Point(94, 9);
            label1.Name = "label1";
            label1.Size = new Size(244, 43);
            label1.TabIndex = 0;
            label1.Text = "The entered UPC matches multiple comics. Select the comic you want to add.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SelectionDataGridView
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SelectionDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            SelectionDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            SelectionDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            SelectionDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SelectionDataGridView.Columns.AddRange(new DataGridViewColumn[] { SelectionTitleColumn, SelectionIssueColumn, SelectionPublisherColumn, SelectionYearColumn });
            SelectionDataGridView.Location = new Point(12, 70);
            SelectionDataGridView.MultiSelect = false;
            SelectionDataGridView.Name = "SelectionDataGridView";
            SelectionDataGridView.ReadOnly = true;
            SelectionDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SelectionDataGridView.Size = new Size(404, 254);
            SelectionDataGridView.TabIndex = 1;
            SelectionDataGridView.CellDoubleClick += SelectionDataGridView_CellDoubleClick;
            // 
            // SelectionTitleColumn
            // 
            SelectionTitleColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SelectionTitleColumn.HeaderText = "TITLE";
            SelectionTitleColumn.Name = "SelectionTitleColumn";
            SelectionTitleColumn.ReadOnly = true;
            // 
            // SelectionIssueColumn
            // 
            SelectionIssueColumn.HeaderText = "ISSUE";
            SelectionIssueColumn.Name = "SelectionIssueColumn";
            SelectionIssueColumn.ReadOnly = true;
            SelectionIssueColumn.Width = 60;
            // 
            // SelectionPublisherColumn
            // 
            SelectionPublisherColumn.HeaderText = "PUBLISHER";
            SelectionPublisherColumn.Name = "SelectionPublisherColumn";
            SelectionPublisherColumn.ReadOnly = true;
            SelectionPublisherColumn.Width = 90;
            // 
            // SelectionYearColumn
            // 
            SelectionYearColumn.HeaderText = "YEAR";
            SelectionYearColumn.Name = "SelectionYearColumn";
            SelectionYearColumn.ReadOnly = true;
            SelectionYearColumn.Width = 60;
            // 
            // ExitSelectionButton
            // 
            ExitSelectionButton.Anchor = AnchorStyles.Bottom;
            ExitSelectionButton.Location = new Point(349, 330);
            ExitSelectionButton.Name = "ExitSelectionButton";
            ExitSelectionButton.Size = new Size(58, 23);
            ExitSelectionButton.TabIndex = 2;
            ExitSelectionButton.Text = "Exit";
            ExitSelectionButton.UseVisualStyleBackColor = true;
            ExitSelectionButton.Click += ExitSelectionButton_Click;
            // 
            // ComicSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 359);
            Controls.Add(ExitSelectionButton);
            Controls.Add(SelectionDataGridView);
            Controls.Add(label1);
            Name = "ComicSelectionForm";
            Text = "Select Comic";
            ((System.ComponentModel.ISupportInitialize)SelectionDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView SelectionDataGridView;
        private Button ExitSelectionButton;
        private DataGridViewTextBoxColumn SelectionTitleColumn;
        private DataGridViewTextBoxColumn SelectionIssueColumn;
        private DataGridViewTextBoxColumn SelectionPublisherColumn;
        private DataGridViewTextBoxColumn SelectionYearColumn;
    }
}