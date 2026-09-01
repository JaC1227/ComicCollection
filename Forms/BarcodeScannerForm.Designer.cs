namespace ComicCollection.Forms
{
    partial class BarcodeScannerForm
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
            CameraPictureBox = new PictureBox();
            ExitButton = new Button();
            StatusLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)CameraPictureBox).BeginInit();
            SuspendLayout();
            // 
            // CameraPictureBox
            // 
            CameraPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CameraPictureBox.Location = new Point(32, 12);
            CameraPictureBox.Name = "CameraPictureBox";
            CameraPictureBox.Size = new Size(272, 267);
            CameraPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            CameraPictureBox.TabIndex = 0;
            CameraPictureBox.TabStop = false;
            // 
            // ExitButton
            // 
            ExitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ExitButton.Location = new Point(283, 296);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(43, 23);
            ExitButton.TabIndex = 1;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.Anchor = AnchorStyles.Bottom;
            StatusLabel.Location = new Point(82, 296);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(181, 23);
            StatusLabel.TabIndex = 2;
            StatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BarcodeScannerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 322);
            Controls.Add(StatusLabel);
            Controls.Add(ExitButton);
            Controls.Add(CameraPictureBox);
            Name = "BarcodeScannerForm";
            Text = "Barcode Scanner";
            FormClosing += BarcodeScannerForm_FormClosing;
            Load += BarcodeScammerFormLoad;
            ((System.ComponentModel.ISupportInitialize)CameraPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CameraPictureBox;
        private Button ExitButton;
        private Label StatusLabel;
    }
}