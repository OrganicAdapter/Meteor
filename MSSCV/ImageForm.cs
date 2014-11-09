using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bsmrq.Imaging.AForgeExtensions.Extensions;
using MSSCV.RainDetector.Models;
using MSSCV.RainDetector.Services;
using MSSCV.RainDetector;
using System.Xml.Linq;
using MSSCV.RainDetector.Constants;

namespace MSSCV
{
    public partial class ImageForm : Form
    {
        private readonly IRaindropDetector _rainDetectionService;
        private readonly IRainDetectionTester _rainDetectionTester;


        public IDictionary<IDescriptedKey, Bitmap> Images { get; set; }


        public ImageForm(IDictionary<IDescriptedKey, Bitmap> images)
        {
            _rainDetectionService = new RaindropDetector();
            _rainDetectionTester = new RainDetectionTester(_rainDetectionService);

            InitializeComponent();

            Images = images;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            imageSelectorComboBox.Items.AddRange(Images.Keys.ToArray());
            imageSelectorComboBox.SelectedIndex = 0;
        }


        private void SetProcessingStatus(bool value)
        {
            const string processingText = " (Processing...)";

            if (value && !Text.Contains(processingText))
            {
                Text = String.Format("{0}{1}", Text, processingText);
            }

            if (!value && Text.Contains(processingText))
            {
                Text = Text.Replace(processingText, String.Empty);
            }
        }

        private void thresholdt125ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetProcessingStatus(true);

            SetProcessingStatus(false);

        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetProcessingStatus(true);

            SetProcessingStatus(false);
        }

        private async void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap selectedImage = null;
            using (var detectionParameterDialog = new DetectionParameterDialog(Images))
            {
                if (detectionParameterDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImage = Images[detectionParameterDialog.SelectedImageKey];
                }
            }

            if (selectedImage != null)
            {
                SetProcessingStatus(true);

                var context = new RaindropDetectionContext
                {
                    Images = new Dictionary<IDescriptedKey, Bitmap> { { ImageKeys.SourceImages.Latest, selectedImage } }
                };

                await _rainDetectionService.Detect(context);

                SetProcessingStatus(false);

                new DetectionForm(context) { MdiParent = this.MdiParent }.Show();
            }
        }

        private void imageSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selector = sender as ComboBox;
            var selectedImageKey = selector.SelectedItem as IDescriptedKey;
            var selectedImage = Images[selectedImageKey];

            imagePictureBox.Image = selectedImage;

            imageSizeTextBox.Text = String.Format("{0} x {1}", selectedImage.Size.Width, selectedImage.Size.Height);
        }

        private void addtestRegionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap selectedImage = null;
            using (var detectionParameterDialog = new DetectionParameterDialog(Images))
            {
                if (detectionParameterDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImage = Images[detectionParameterDialog.SelectedImageKey];
                }
            }

            if (selectedImage != null)
            {
                var createRegionsForm = new BitmapRegionGeneratorDialog(selectedImage);

                if (createRegionsForm.ShowDialog() == DialogResult.OK)
                {
                    if (createRegionsForm.AdjustedRegions.Any())
                    {
                        using (var sfd = new SaveFileDialog())
                        {
                            sfd.DefaultExt = "XML file|*.xml";

                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                var xdoc = new XDocument();
                                xdoc.Add(new XElement("Rectangles"));

                                foreach (var region in createRegionsForm.AdjustedRegions)
                                {
                                    xdoc.Root.Add(new XElement("Rectangle",
                                        new XElement("X", region.Location.X),
                                        new XElement("Y", region.Location.Y),
                                        new XElement("Width", region.Width),
                                        new XElement("Height", region.Height)));
                                }

                                xdoc.Save(sfd.FileName);

                                MessageBox.Show("Test file was successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private async void runtestOnRegionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap selectedImage = null;
            using (var detectionParameterDialog = new DetectionParameterDialog(Images))
            {
                if (detectionParameterDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImage = Images[detectionParameterDialog.SelectedImageKey];
                }
            }

            if (selectedImage != null)
            {
                using (var ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        var xdoc = XDocument.Load(ofd.FileName);

                        var regions = xdoc.Root.Elements("Rectangle").Select(element =>
                            new Rectangle(
                                new Point(int.Parse(element.Element("X").Value), int.Parse(element.Element("Y").Value)),
                                new Size(int.Parse(element.Element("Width").Value), int.Parse(element.Element("Height").Value))));

                        SetProcessingStatus(true);

                        var context = new RaindropDetectionContext
                        {
                            Images = new Dictionary<IDescriptedKey, Bitmap> { { ImageKeys.SourceImages.Latest, selectedImage } }
                        };

                        await _rainDetectionTester.Run(context, regions.ToList());

                        SetProcessingStatus(false);

                        new DetectionForm(context) { MdiParent = this.MdiParent }.Show();
                    }
                }
            }
        }
    }
}
