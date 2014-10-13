namespace RainDetector.Forms
{
    partial class DetectionSequenceForm
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
            this.btnDetect = new System.Windows.Forms.Button();
            this.pbSource = new System.Windows.Forms.PictureBox();
            this.pbPreProcessingResult = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCountOfPotentialDrops = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbDetectionResult = new System.Windows.Forms.PictureBox();
            this.lblCountOfDetectedRaindrops = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pbBlobDetectedImage = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbFilteredRectangles = new System.Windows.Forms.PictureBox();
            this.lblCountOfFilteredPotentialDrops = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pbOriginalHist = new System.Windows.Forms.PictureBox();
            this.pbAvgHist = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreProcessingResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetectionResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlobDetectedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilteredRectangles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvgHist)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(153, 205);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(90, 23);
            this.btnDetect.TabIndex = 3;
            this.btnDetect.Text = "Indít";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.BtnDetect_Click);
            // 
            // pbSource
            // 
            this.pbSource.Location = new System.Drawing.Point(12, 12);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(231, 187);
            this.pbSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSource.TabIndex = 4;
            this.pbSource.TabStop = false;
            // 
            // pbPreProcessingResult
            // 
            this.pbPreProcessingResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreProcessingResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPreProcessingResult.Location = new System.Drawing.Point(12, 282);
            this.pbPreProcessingResult.Name = "pbPreProcessingResult";
            this.pbPreProcessingResult.Size = new System.Drawing.Size(231, 187);
            this.pbPreProcessingResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreProcessingResult.TabIndex = 5;
            this.pbPreProcessingResult.TabStop = false;
            this.pbPreProcessingResult.Click += new System.EventHandler(this.ResultImageClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Előfeldolgozás eredménye:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Potenciális területek száma:";
            // 
            // lblCountOfPotentialDrops
            // 
            this.lblCountOfPotentialDrops.AutoSize = true;
            this.lblCountOfPotentialDrops.Location = new System.Drawing.Point(436, 472);
            this.lblCountOfPotentialDrops.Name = "lblCountOfPotentialDrops";
            this.lblCountOfPotentialDrops.Size = new System.Drawing.Size(13, 17);
            this.lblCountOfPotentialDrops.TabIndex = 10;
            this.lblCountOfPotentialDrops.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(732, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Detektálás eredménye:";
            // 
            // pbDetectionResult
            // 
            this.pbDetectionResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDetectionResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDetectionResult.Location = new System.Drawing.Point(732, 282);
            this.pbDetectionResult.Name = "pbDetectionResult";
            this.pbDetectionResult.Size = new System.Drawing.Size(231, 187);
            this.pbDetectionResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDetectionResult.TabIndex = 11;
            this.pbDetectionResult.TabStop = false;
            this.pbDetectionResult.Click += new System.EventHandler(this.ResultImageClicked);
            // 
            // lblCountOfDetectedRaindrops
            // 
            this.lblCountOfDetectedRaindrops.AutoSize = true;
            this.lblCountOfDetectedRaindrops.Location = new System.Drawing.Point(1000, 472);
            this.lblCountOfDetectedRaindrops.Name = "lblCountOfDetectedRaindrops";
            this.lblCountOfDetectedRaindrops.Size = new System.Drawing.Size(13, 17);
            this.lblCountOfDetectedRaindrops.TabIndex = 14;
            this.lblCountOfDetectedRaindrops.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(729, 472);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Detektált esőcseppek száma:";
            // 
            // pbBlobDetectedImage
            // 
            this.pbBlobDetectedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBlobDetectedImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBlobDetectedImage.Location = new System.Drawing.Point(249, 282);
            this.pbBlobDetectedImage.Name = "pbBlobDetectedImage";
            this.pbBlobDetectedImage.Size = new System.Drawing.Size(231, 187);
            this.pbBlobDetectedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBlobDetectedImage.TabIndex = 15;
            this.pbBlobDetectedImage.TabStop = false;
            this.pbBlobDetectedImage.Click += new System.EventHandler(this.ResultImageClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(249, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Potenciális területek:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(486, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Potenciális területek szűrés után:";
            // 
            // pbFilteredRectangles
            // 
            this.pbFilteredRectangles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFilteredRectangles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFilteredRectangles.Location = new System.Drawing.Point(486, 282);
            this.pbFilteredRectangles.Name = "pbFilteredRectangles";
            this.pbFilteredRectangles.Size = new System.Drawing.Size(231, 187);
            this.pbFilteredRectangles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFilteredRectangles.TabIndex = 17;
            this.pbFilteredRectangles.TabStop = false;
            this.pbFilteredRectangles.Click += new System.EventHandler(this.ResultImageClicked);
            // 
            // lblCountOfFilteredPotentialDrops
            // 
            this.lblCountOfFilteredPotentialDrops.AutoSize = true;
            this.lblCountOfFilteredPotentialDrops.Location = new System.Drawing.Point(676, 472);
            this.lblCountOfFilteredPotentialDrops.Name = "lblCountOfFilteredPotentialDrops";
            this.lblCountOfFilteredPotentialDrops.Size = new System.Drawing.Size(13, 17);
            this.lblCountOfFilteredPotentialDrops.TabIndex = 20;
            this.lblCountOfFilteredPotentialDrops.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(486, 472);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Potenciális területek száma:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(707, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Eredeti kép hisztogramja:";
            // 
            // pbOriginalHist
            // 
            this.pbOriginalHist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOriginalHist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOriginalHist.Location = new System.Drawing.Point(707, 32);
            this.pbOriginalHist.Name = "pbOriginalHist";
            this.pbOriginalHist.Size = new System.Drawing.Size(256, 90);
            this.pbOriginalHist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOriginalHist.TabIndex = 23;
            this.pbOriginalHist.TabStop = false;
            this.pbOriginalHist.Click += new System.EventHandler(this.ResultImageClicked);
            // 
            // pbAvgHist
            // 
            this.pbAvgHist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAvgHist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAvgHist.Location = new System.Drawing.Point(707, 149);
            this.pbAvgHist.Name = "pbAvgHist";
            this.pbAvgHist.Size = new System.Drawing.Size(256, 90);
            this.pbAvgHist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAvgHist.TabIndex = 25;
            this.pbAvgHist.TabStop = false;
            this.pbAvgHist.Click += new System.EventHandler(this.ResultImageClicked);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(707, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(273, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Potenciális területek átlagos hisztogramja:";
            // 
            // DetectionSequenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 500);
            this.Controls.Add(this.pbAvgHist);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pbOriginalHist);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCountOfFilteredPotentialDrops);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbFilteredRectangles);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pbBlobDetectedImage);
            this.Controls.Add(this.lblCountOfDetectedRaindrops);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbDetectionResult);
            this.Controls.Add(this.lblCountOfPotentialDrops);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbPreProcessingResult);
            this.Controls.Add(this.pbSource);
            this.Controls.Add(this.btnDetect);
            this.Name = "DetectionSequenceForm";
            this.Text = "Detektálás";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DetectionSequenceForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreProcessingResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetectionResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlobDetectedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilteredRectangles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginalHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvgHist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.PictureBox pbSource;
        private System.Windows.Forms.PictureBox pbPreProcessingResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCountOfPotentialDrops;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbDetectionResult;
        private System.Windows.Forms.Label lblCountOfDetectedRaindrops;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pbBlobDetectedImage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbFilteredRectangles;
        private System.Windows.Forms.Label lblCountOfFilteredPotentialDrops;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbOriginalHist;
        private System.Windows.Forms.PictureBox pbAvgHist;
        private System.Windows.Forms.Label label10;

    }
}