namespace MSSCV
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdt125ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rainDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.imageSizeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addtestRegionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runtestOnRegionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testActionsToolStripMenuItem,
            this.rainDetectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(346, 24);
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
            this.defaultToolStripMenuItem,
            this.toolStripSeparator1,
            this.addtestRegionsToolStripMenuItem,
            this.runtestOnRegionsToolStripMenuItem});
            this.rainDetectionToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.rainDetectionToolStripMenuItem.MergeIndex = 3;
            this.rainDetectionToolStripMenuItem.Name = "rainDetectionToolStripMenuItem";
            this.rainDetectionToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.rainDetectionToolStripMenuItem.Text = "&Rain Detection";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.defaultToolStripMenuItem.Text = "&Default...";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
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
            this.imageSelectorComboBox.TabIndex = 3;
            this.imageSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.imageSelectorComboBox_SelectedIndexChanged);
            // 
            // imageSizeTextBox
            // 
            this.imageSizeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageSizeTextBox.Location = new System.Drawing.Point(78, 285);
            this.imageSizeTextBox.Name = "imageSizeTextBox";
            this.imageSizeTextBox.ReadOnly = true;
            this.imageSizeTextBox.Size = new System.Drawing.Size(254, 20);
            this.imageSizeTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Image size:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // addtestRegionsToolStripMenuItem
            // 
            this.addtestRegionsToolStripMenuItem.Name = "addtestRegionsToolStripMenuItem";
            this.addtestRegionsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.addtestRegionsToolStripMenuItem.Text = "Add test &regions...";
            this.addtestRegionsToolStripMenuItem.Click += new System.EventHandler(this.addtestRegionsToolStripMenuItem_Click);
            // 
            // runtestOnRegionsToolStripMenuItem
            // 
            this.runtestOnRegionsToolStripMenuItem.Name = "runtestOnRegionsToolStripMenuItem";
            this.runtestOnRegionsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.runtestOnRegionsToolStripMenuItem.Text = "Run &test on regions...";
            this.runtestOnRegionsToolStripMenuItem.Click += new System.EventHandler(this.runtestOnRegionsToolStripMenuItem_Click);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 317);
            this.Controls.Add(this.imageSizeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageSelectorComboBox);
            this.Controls.Add(this.imagePictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImageForm";
            this.Text = "Original Image";
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdt125ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greyscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rainDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ComboBox imageSelectorComboBox;
        private System.Windows.Forms.TextBox imageSizeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addtestRegionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runtestOnRegionsToolStripMenuItem;
    }
}