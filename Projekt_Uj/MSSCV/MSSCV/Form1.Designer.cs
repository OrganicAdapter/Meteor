namespace MSSCV
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.felhőMegnyitásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subresultGrid = new System.Windows.Forms.DataGridView();
            this.resultGrid = new System.Windows.Forms.DataGridView();
            this.felhőMozgásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subresultGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(712, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.felhőMegnyitásToolStripMenuItem,
            this.felhőMozgásToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&Fájl";
            // 
            // felhőMegnyitásToolStripMenuItem
            // 
            this.felhőMegnyitásToolStripMenuItem.Name = "felhőMegnyitásToolStripMenuItem";
            this.felhőMegnyitásToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.felhőMegnyitásToolStripMenuItem.Text = "&Felhő detektálás...";
            this.felhőMegnyitásToolStripMenuItem.Click += new System.EventHandler(this.DetectCloudMenuItem_Click);
            // 
            // subresultGrid
            // 
            this.subresultGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subresultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.subresultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subresultGrid.Location = new System.Drawing.Point(0, 24);
            this.subresultGrid.Name = "subresultGrid";
            this.subresultGrid.Size = new System.Drawing.Size(399, 474);
            this.subresultGrid.TabIndex = 1;
            // 
            // resultGrid
            // 
            this.resultGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Location = new System.Drawing.Point(405, 24);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.Size = new System.Drawing.Size(307, 474);
            this.resultGrid.TabIndex = 2;
            // 
            // felhőMozgásToolStripMenuItem
            // 
            this.felhőMozgásToolStripMenuItem.Name = "felhőMozgásToolStripMenuItem";
            this.felhőMozgásToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.felhőMozgásToolStripMenuItem.Text = "&Felhő mozgás...";
            this.felhőMozgásToolStripMenuItem.Click += new System.EventHandler(this.CloudMovementMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 498);
            this.Controls.Add(this.resultGrid);
            this.Controls.Add(this.subresultGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subresultGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem felhőMegnyitásToolStripMenuItem;
        private System.Windows.Forms.DataGridView subresultGrid;
        private System.Windows.Forms.DataGridView resultGrid;
        private System.Windows.Forms.ToolStripMenuItem felhőMozgásToolStripMenuItem;
    }
}

