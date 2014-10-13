using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bsmrq.Imaging.AForgeExtensions.Extensions;
using DSP.RainDetector.Models;
using DSP.RainDetector.Services;

namespace DSP
{
    public partial class ImageForm : Form
    {
        private readonly IRainDetectionService _rainDetectionService;


        public Size ImageSize { get; set; }

        public Bitmap Image { get; set; }

        public IList<string> History { get; set; }

        public IDictionary<string, string> CustomImageImageProperties { get; set; }


        public ImageForm(
            Bitmap image, 
            IDictionary<string, string> customImageProperties, 
            IList<string> history)
        {
            _rainDetectionService = new DefaultRainDetectionService();

            InitializeComponent();

            Image = image;
            CustomImageImageProperties = customImageProperties;
            History = history;
        }

        public ImageForm(Bitmap image)
            : this(image, new Dictionary<string, string>(), new List<string>()) { }

        public ImageForm(Bitmap image, IDictionary<string, string> customImageProperties)
            : this(image, customImageProperties, new List<string>()) { }

        public ImageForm(Bitmap image, IList<string> history)
            : this(image, new Dictionary<string, string>(), history) { }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ImageSize = Image.Size;

            if (History.Count > 1 || (History.Count == 1 && History.First() != "Opened"))
            {
                Text = "Modified Image";
            }
            
            imagePictureBox.Image = Image;
            imageSizeTextBox.Text = ImageSize.ToString();
            customPropertiesRichTextBox.Text = String.Join(Environment.NewLine, CustomImageImageProperties.Select(
                property => String.Format("{0}: {1}", property.Key, property.Value)));
            historyRichTextBox.Text = String.Join(Environment.NewLine, History);
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

            var newImage = Image.ApplyThreshold(125);

            SetProcessingStatus(false);

            new ImageForm(newImage, History.Union(new[] {"Threshold (125)"}).ToList()) {MdiParent = MdiParent}
                .Show();
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetProcessingStatus(true);

            var newImage = Image.ApplyGrayscale();

            SetProcessingStatus(false);

            new ImageForm(newImage, History.Union(new[] { "Grayscale" }).ToList()) { MdiParent = MdiParent }
                .Show();
        }

        private async void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetProcessingStatus(true);

            var context = await _rainDetectionService.Detect(new RainDetectionContext
            {
                OriginalImage = Image,
                History = History
            });

            SetProcessingStatus(false);

            new ImageForm(context.FinalImage,
                new Dictionary<string, string> {{"Raindrops", context.RaindropCount.ToString()}},
                context.History)
            {
                MdiParent = MdiParent
            }
                .Show();
        }
    }
}
