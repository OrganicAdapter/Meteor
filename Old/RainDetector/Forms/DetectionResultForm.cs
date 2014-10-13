using RainDetector.ViewModels;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace RainDetector.Forms
{
    public partial class DetectionResultForm : Form
    {
        private readonly RainDetectionFilterResultViewModel _result;


        public DetectionResultForm(RainDetectionFilterResultViewModel result)
        {
            InitializeComponent();

            _result = result;
        }

        public DetectionResultForm(Bitmap result)
        {
            InitializeComponent();

            _result = new RainDetectionFilterResultViewModel { ResultImage = result };
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            pbResult.Image = _result.ResultImage;

            if (!String.IsNullOrEmpty(_result.FilterDetails))
            {
                Text = String.Format("{0} - {1}", Text, _result.FilterDetails);
            }
        }


        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog
            {
                InitialDirectory = Path.Combine(Environment.CurrentDirectory, "SampleImages"),
                Filter = "Jpeg kép (*.jpg)|*.jpg"
            })
            {
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _result.ResultImage.Save(sfd.FileName, ImageFormat.Jpeg);
                }
            }
        }
    }
}
