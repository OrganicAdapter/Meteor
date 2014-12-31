namespace DSP
{
    partial class ManualCloudThresholdConfiguration
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
            this.stratusPictureBox = new System.Windows.Forms.PictureBox();
            this.cumulusPictureBox = new System.Windows.Forms.PictureBox();
            this.mixedPictureBox = new System.Windows.Forms.PictureBox();
            this.thresholdLowerBar = new System.Windows.Forms.TrackBar();
            this.thresholdUpperBar = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openStratusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCumulusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMixedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originalStratus = new System.Windows.Forms.PictureBox();
            this.originalCumulus = new System.Windows.Forms.PictureBox();
            this.originalMixed = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.stratusPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cumulusPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdLowerBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdUpperBar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalStratus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalCumulus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalMixed)).BeginInit();
            this.SuspendLayout();
            // 
            // stratusPictureBox
            // 
            this.stratusPictureBox.Location = new System.Drawing.Point(12, 191);
            this.stratusPictureBox.Name = "stratusPictureBox";
            this.stratusPictureBox.Size = new System.Drawing.Size(243, 169);
            this.stratusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.stratusPictureBox.TabIndex = 0;
            this.stratusPictureBox.TabStop = false;
            // 
            // cumulusPictureBox
            // 
            this.cumulusPictureBox.Location = new System.Drawing.Point(261, 191);
            this.cumulusPictureBox.Name = "cumulusPictureBox";
            this.cumulusPictureBox.Size = new System.Drawing.Size(243, 169);
            this.cumulusPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cumulusPictureBox.TabIndex = 1;
            this.cumulusPictureBox.TabStop = false;
            // 
            // mixedPictureBox
            // 
            this.mixedPictureBox.Location = new System.Drawing.Point(510, 191);
            this.mixedPictureBox.Name = "mixedPictureBox";
            this.mixedPictureBox.Size = new System.Drawing.Size(246, 169);
            this.mixedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mixedPictureBox.TabIndex = 2;
            this.mixedPictureBox.TabStop = false;
            // 
            // thresholdLowerBar
            // 
            this.thresholdLowerBar.Location = new System.Drawing.Point(12, 417);
            this.thresholdLowerBar.Maximum = 256;
            this.thresholdLowerBar.Name = "thresholdLowerBar";
            this.thresholdLowerBar.Size = new System.Drawing.Size(744, 45);
            this.thresholdLowerBar.TabIndex = 3;
            this.thresholdLowerBar.Scroll += new System.EventHandler(this.thresholdLowerBar_Scroll);
            // 
            // thresholdUpperBar
            // 
            this.thresholdUpperBar.Location = new System.Drawing.Point(10, 366);
            this.thresholdUpperBar.Maximum = 256;
            this.thresholdUpperBar.Name = "thresholdUpperBar";
            this.thresholdUpperBar.Size = new System.Drawing.Size(744, 45);
            this.thresholdUpperBar.TabIndex = 4;
            this.thresholdUpperBar.Scroll += new System.EventHandler(this.thresholdUpperBar_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(766, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openStratusToolStripMenuItem,
            this.openCumulusToolStripMenuItem,
            this.openMixedToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openStratusToolStripMenuItem
            // 
            this.openStratusToolStripMenuItem.Name = "openStratusToolStripMenuItem";
            this.openStratusToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openStratusToolStripMenuItem.Text = "&Open stratus...";
            this.openStratusToolStripMenuItem.Click += new System.EventHandler(this.openStratusToolStripMenuItem_Click);
            // 
            // openCumulusToolStripMenuItem
            // 
            this.openCumulusToolStripMenuItem.Name = "openCumulusToolStripMenuItem";
            this.openCumulusToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openCumulusToolStripMenuItem.Text = "&Open cumulus...";
            this.openCumulusToolStripMenuItem.Click += new System.EventHandler(this.openCumulusToolStripMenuItem_Click);
            // 
            // openMixedToolStripMenuItem
            // 
            this.openMixedToolStripMenuItem.Name = "openMixedToolStripMenuItem";
            this.openMixedToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openMixedToolStripMenuItem.Text = "&Open mixed...";
            this.openMixedToolStripMenuItem.Click += new System.EventHandler(this.openMixedToolStripMenuItem_Click);
            // 
            // originalStratus
            // 
            this.originalStratus.Location = new System.Drawing.Point(12, 27);
            this.originalStratus.Name = "originalStratus";
            this.originalStratus.Size = new System.Drawing.Size(243, 158);
            this.originalStratus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalStratus.TabIndex = 6;
            this.originalStratus.TabStop = false;
            // 
            // originalCumulus
            // 
            this.originalCumulus.Location = new System.Drawing.Point(261, 27);
            this.originalCumulus.Name = "originalCumulus";
            this.originalCumulus.Size = new System.Drawing.Size(243, 158);
            this.originalCumulus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalCumulus.TabIndex = 7;
            this.originalCumulus.TabStop = false;
            // 
            // originalMixed
            // 
            this.originalMixed.Location = new System.Drawing.Point(510, 27);
            this.originalMixed.Name = "originalMixed";
            this.originalMixed.Size = new System.Drawing.Size(246, 158);
            this.originalMixed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalMixed.TabIndex = 8;
            this.originalMixed.TabStop = false;
            // 
            // ManualCloudThresholdConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 474);
            this.Controls.Add(this.originalMixed);
            this.Controls.Add(this.originalCumulus);
            this.Controls.Add(this.originalStratus);
            this.Controls.Add(this.thresholdUpperBar);
            this.Controls.Add(this.thresholdLowerBar);
            this.Controls.Add(this.mixedPictureBox);
            this.Controls.Add(this.cumulusPictureBox);
            this.Controls.Add(this.stratusPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManualCloudThresholdConfiguration";
            this.Text = "ManualCloudThresholdConfiguration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManualCloudThresholdConfiguration_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.stratusPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cumulusPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdLowerBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdUpperBar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalStratus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalCumulus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalMixed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox stratusPictureBox;
        private System.Windows.Forms.PictureBox cumulusPictureBox;
        private System.Windows.Forms.PictureBox mixedPictureBox;
        private System.Windows.Forms.TrackBar thresholdLowerBar;
        private System.Windows.Forms.TrackBar thresholdUpperBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openStratusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCumulusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMixedToolStripMenuItem;
        private System.Windows.Forms.PictureBox originalStratus;
        private System.Windows.Forms.PictureBox originalCumulus;
        private System.Windows.Forms.PictureBox originalMixed;
    }
}