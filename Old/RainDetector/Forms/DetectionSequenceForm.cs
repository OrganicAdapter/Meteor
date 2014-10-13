using DarkSkyProject.Common.Models;
using RainDetector.Lib.Services;
using RainDetector.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RainDetector.Forms
{
    public partial class DetectionSequenceForm : Form
    {
        private readonly IRainDetectionService _rainDetectionService;
        private readonly ICommonImageSource _commonImageSource;
        private readonly List<RainDetectionFilterResultViewModel> _resultList;


        public DetectionSequenceForm(IRainDetectionService rainDetectionService, ICommonImageSource commonImageSource)
        {
            InitializeComponent();

            _rainDetectionService = rainDetectionService;
            _commonImageSource = commonImageSource;
            _resultList = new List<RainDetectionFilterResultViewModel>();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            pbSource.DataBindings.Add(new Binding("Image", _commonImageSource, "CurrentImage"));
        }


        private async void BtnDetect_Click(object sender, EventArgs e)
        {
            _resultList.Clear();

            pbBlobDetectedImage.Image = null;
            pbDetectionResult.Image = null;
            pbFilteredRectangles.Image = null;
            pbPreProcessingResult.Image = null;

            lblCountOfDetectedRaindrops.Text = "-";
            lblCountOfFilteredPotentialDrops.Text = "-";
            lblCountOfPotentialDrops.Text = "-";

            var result = await _rainDetectionService.DetectRaindrops(_commonImageSource.CurrentImage);


            pbOriginalHist.Image = result.OriginalHistogram;
            pbPreProcessingResult.Image = result.PreProcessedImage;
            pbFilteredRectangles.Image = result.FilteredBlobDetectedImage;
            lblCountOfFilteredPotentialDrops.Text = result.FilteredBlobCount.ToString();
            pbBlobDetectedImage.Image = result.BlobDetectedImage;
            lblCountOfPotentialDrops.Text = result.BlobCount.ToString();
            pbAvgHist.Image = result.AverageHistogram;

            _commonImageSource.SetImage("PreProcessedRainyImage", result.PreProcessedImage);
            _commonImageSource.SetImage("DetectedRaindrops", result.FilteredBlobDetectedImage);
        }

        private void ResultImageClicked(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;

            var resultForm = new DetectionResultForm(pb.Image as Bitmap) { MdiParent = MdiParent };

            resultForm.Show();
        }

        private void DetectionSequenceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
