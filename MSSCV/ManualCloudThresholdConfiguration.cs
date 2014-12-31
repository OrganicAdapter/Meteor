using CloudDetection.Models;
using CloudDetection.ViewModels;
using MSSCV.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSP
{
    public partial class ManualCloudThresholdConfiguration : Form
    {
        public Bitmap Cumulus { get; set; }
        public Bitmap Stratus { get; set; }
        public Bitmap Mixed { get; set; }

        public CloudDetectionViewModel Service { get; set; }

        public ManualCloudThresholdConfiguration()
        {
            Service = new CloudDetectionViewModel();

            InitializeComponent();

            Service.SetValues();
            thresholdUpperBar.Value = Service.SkyLower;
            thresholdLowerBar.Value = Service.CloudUpper;
        }

        private Bitmap ResizeImage(Bitmap image)
        {
            double help = image.Height / 200;

            image = new Bitmap(image, (int)(image.Width / help), (int)(image.Height / help));

            return image;
        }

        private void openStratusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stratus = OpenFileService.OpenSingleImage();
            Stratus = ResizeImage(Stratus);

            originalStratus.Image = Stratus;

            GetThresholdForAll();
        }

        private void openCumulusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cumulus = OpenFileService.OpenSingleImage();
            Cumulus = ResizeImage(Cumulus);

            originalCumulus.Image = Cumulus;

            GetThresholdForAll();
        }

        private void openMixedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mixed = OpenFileService.OpenSingleImage();
            Mixed = ResizeImage(Mixed);

            originalMixed.Image = Mixed;

            GetThresholdForAll();
        }

        private void thresholdLowerBar_Scroll(object sender, EventArgs e)
        {
            if (thresholdLowerBar.Value > thresholdUpperBar.Value)
                thresholdUpperBar.Value = thresholdLowerBar.Value;

            GetThresholdForAll();
        }

        private void thresholdUpperBar_Scroll(object sender, EventArgs e)
        {
            if (thresholdLowerBar.Value > thresholdUpperBar.Value)
                thresholdLowerBar.Value = thresholdUpperBar.Value;

            GetThresholdForAll();
        }

        private async void GetThresholdForAll()
        {
            try
            {
                cumulusPictureBox.Image = await Service.GetThresholdedImage(new Bitmap(Cumulus), thresholdUpperBar.Value, thresholdLowerBar.Value);
            }
            catch
            { 
            
            }

            try
            {
                stratusPictureBox.Image = await Service.GetThresholdedImage(new Bitmap(Stratus), thresholdUpperBar.Value, thresholdLowerBar.Value);
            }
            catch
            {

            }

            try
            {
                mixedPictureBox.Image = await Service.GetThresholdedImage(new Bitmap(Mixed), thresholdUpperBar.Value, thresholdLowerBar.Value);
            }
            catch
            {

            }
        }

        private void ManualCloudThresholdConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Service.SaveValues(thresholdLowerBar.Value, thresholdUpperBar.Value);
            Service.SetValues();
        }
    }
}
