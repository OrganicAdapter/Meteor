namespace DSP
{
    partial class DetectionForm
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
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.imageDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customPropertiesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.historyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imageSelectorComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.imageDetailsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePictureBox.Location = new System.Drawing.Point(12, 39);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(320, 240);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePictureBox.TabIndex = 0;
            this.imagePictureBox.TabStop = false;
            // 
            // imageDetailsGroupBox
            // 
            this.imageDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageDetailsGroupBox.Controls.Add(this.label1);
            this.imageDetailsGroupBox.Controls.Add(this.customPropertiesRichTextBox);
            this.imageDetailsGroupBox.Controls.Add(this.historyRichTextBox);
            this.imageDetailsGroupBox.Controls.Add(this.label3);
            this.imageDetailsGroupBox.Location = new System.Drawing.Point(345, 12);
            this.imageDetailsGroupBox.Name = "imageDetailsGroupBox";
            this.imageDetailsGroupBox.Size = new System.Drawing.Size(240, 268);
            this.imageDetailsGroupBox.TabIndex = 1;
            this.imageDetailsGroupBox.TabStop = false;
            this.imageDetailsGroupBox.Text = "Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Custom properties:";
            // 
            // customPropertiesRichTextBox
            // 
            this.customPropertiesRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.customPropertiesRichTextBox.Location = new System.Drawing.Point(8, 32);
            this.customPropertiesRichTextBox.Name = "customPropertiesRichTextBox";
            this.customPropertiesRichTextBox.ReadOnly = true;
            this.customPropertiesRichTextBox.Size = new System.Drawing.Size(225, 40);
            this.customPropertiesRichTextBox.TabIndex = 6;
            this.customPropertiesRichTextBox.Text = "";
            // 
            // historyRichTextBox
            // 
            this.historyRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.historyRichTextBox.Location = new System.Drawing.Point(9, 91);
            this.historyRichTextBox.Name = "historyRichTextBox";
            this.historyRichTextBox.ReadOnly = true;
            this.historyRichTextBox.Size = new System.Drawing.Size(225, 111);
            this.historyRichTextBox.TabIndex = 5;
            this.historyRichTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "History:";
            // 
            // imageSelectorComboBox
            // 
            this.imageSelectorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageSelectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageSelectorComboBox.FormattingEnabled = true;
            this.imageSelectorComboBox.Location = new System.Drawing.Point(12, 12);
            this.imageSelectorComboBox.Name = "imageSelectorComboBox";
            this.imageSelectorComboBox.Size = new System.Drawing.Size(320, 21);
            this.imageSelectorComboBox.TabIndex = 2;
            this.imageSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.imageSelectorComboBox_SelectedIndexChanged);
            // 
            // DetectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 295);
            this.Controls.Add(this.imageSelectorComboBox);
            this.Controls.Add(this.imageDetailsGroupBox);
            this.Controls.Add(this.imagePictureBox);
            this.Name = "DetectionForm";
            this.Text = "Detection Result";
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.imageDetailsGroupBox.ResumeLayout(false);
            this.imageDetailsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.GroupBox imageDetailsGroupBox;
        private System.Windows.Forms.RichTextBox historyRichTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox customPropertiesRichTextBox;
        private System.Windows.Forms.ComboBox imageSelectorComboBox;
    }
}