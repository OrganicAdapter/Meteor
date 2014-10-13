namespace DSP
{
    partial class ImageForm
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
            this.imageSizeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdt125ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rainDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.imageDetailsGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePictureBox.Location = new System.Drawing.Point(12, 12);
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
            this.imageDetailsGroupBox.Controls.Add(this.imageSizeTextBox);
            this.imageDetailsGroupBox.Controls.Add(this.label2);
            this.imageDetailsGroupBox.Location = new System.Drawing.Point(338, 12);
            this.imageDetailsGroupBox.Name = "imageDetailsGroupBox";
            this.imageDetailsGroupBox.Size = new System.Drawing.Size(240, 240);
            this.imageDetailsGroupBox.TabIndex = 1;
            this.imageDetailsGroupBox.TabStop = false;
            this.imageDetailsGroupBox.Text = "Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Custom properties:";
            // 
            // customPropertiesRichTextBox
            // 
            this.customPropertiesRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.customPropertiesRichTextBox.Location = new System.Drawing.Point(8, 69);
            this.customPropertiesRichTextBox.Name = "customPropertiesRichTextBox";
            this.customPropertiesRichTextBox.ReadOnly = true;
            this.customPropertiesRichTextBox.Size = new System.Drawing.Size(225, 65);
            this.customPropertiesRichTextBox.TabIndex = 6;
            this.customPropertiesRichTextBox.Text = "";
            // 
            // historyRichTextBox
            // 
            this.historyRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.historyRichTextBox.Location = new System.Drawing.Point(9, 153);
            this.historyRichTextBox.Name = "historyRichTextBox";
            this.historyRichTextBox.ReadOnly = true;
            this.historyRichTextBox.Size = new System.Drawing.Size(225, 81);
            this.historyRichTextBox.TabIndex = 5;
            this.historyRichTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "History:";
            // 
            // imageSizeTextBox
            // 
            this.imageSizeTextBox.Location = new System.Drawing.Point(72, 19);
            this.imageSizeTextBox.Name = "imageSizeTextBox";
            this.imageSizeTextBox.ReadOnly = true;
            this.imageSizeTextBox.Size = new System.Drawing.Size(162, 20);
            this.imageSizeTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Image size:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testActionsToolStripMenuItem,
            this.rainDetectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(590, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // testActionsToolStripMenuItem
            // 
            this.testActionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.greyscaleToolStripMenuItem,
            this.thresholdt125ToolStripMenuItem});
            this.testActionsToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.testActionsToolStripMenuItem.MergeIndex = 2;
            this.testActionsToolStripMenuItem.Name = "testActionsToolStripMenuItem";
            this.testActionsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.testActionsToolStripMenuItem.Text = "&Imaging";
            // 
            // greyscaleToolStripMenuItem
            // 
            this.greyscaleToolStripMenuItem.Name = "greyscaleToolStripMenuItem";
            this.greyscaleToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.greyscaleToolStripMenuItem.Text = "&Grayscale...";
            this.greyscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // thresholdt125ToolStripMenuItem
            // 
            this.thresholdt125ToolStripMenuItem.Name = "thresholdt125ToolStripMenuItem";
            this.thresholdt125ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.thresholdt125ToolStripMenuItem.Text = "&Threshold (t=125)...";
            this.thresholdt125ToolStripMenuItem.Click += new System.EventHandler(this.thresholdt125ToolStripMenuItem_Click);
            // 
            // rainDetectionToolStripMenuItem
            // 
            this.rainDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem});
            this.rainDetectionToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.rainDetectionToolStripMenuItem.MergeIndex = 3;
            this.rainDetectionToolStripMenuItem.Name = "rainDetectionToolStripMenuItem";
            this.rainDetectionToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.rainDetectionToolStripMenuItem.Text = "&Rain Detection";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.defaultToolStripMenuItem.Text = "&Default...";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 267);
            this.Controls.Add(this.imageDetailsGroupBox);
            this.Controls.Add(this.imagePictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImageForm";
            this.Text = "Original Image";
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.imageDetailsGroupBox.ResumeLayout(false);
            this.imageDetailsGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.GroupBox imageDetailsGroupBox;
        private System.Windows.Forms.TextBox imageSizeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdt125ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox historyRichTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem greyscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rainDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox customPropertiesRichTextBox;
    }
}