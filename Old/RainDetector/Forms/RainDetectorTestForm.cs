using DarkSkyProject.Common.Models;
using RainDetector.Lib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainDetector.Forms
{
    public partial class RainDetectorTestForm : Form
    {
        private readonly ICommonImageSource _commonImageSource;
        private readonly IImageSplitterService _imageToDarkAndLightSplitterService;
        private readonly IImageProcessingProvider _edgeDetectionPreProcessingProvider;
        private readonly IImageProcessingProvider _commonRainyImagePreProcessingProvider;
        private readonly IRainDetectionMethodService _morphService;
        private readonly IRainDetectionMethodService _edgeDetectionService;


        public RainDetectorTestForm(ICommonImageSource commonImageSource,
            IImageSplitterService imageToDarkAndLightSplitterService,
            IImageProcessingProvider commonRainyImagePreProcessingProvider,
            IImageProcessingProvider edgeDetectionPreProcessingProvider,
            IRainDetectionMethodService morphService,
            IRainDetectionMethodService edgeDetectionService)
        {
            InitializeComponent();

            _commonImageSource = commonImageSource;
            _imageToDarkAndLightSplitterService = imageToDarkAndLightSplitterService;
            _commonRainyImagePreProcessingProvider = commonRainyImagePreProcessingProvider;
            _edgeDetectionPreProcessingProvider = edgeDetectionPreProcessingProvider;
            _morphService = morphService;
            _edgeDetectionService = edgeDetectionService;
        }

        private async void btnTestSplitter_Click(object sender, EventArgs e)
        {
            var images = await _imageToDarkAndLightSplitterService.Split(_commonImageSource.GetImage(txtImageKey.Text));

            for (var i = 0; i < images.Count; i++)
            {
                var image = images[i];

                _commonImageSource.SetImage(String.Format("T_SV_{1}", txtImageKey.Text, i), image);
            }
        }

        private async void btnPreProcess_Click(object sender, EventArgs e)
        {
            var image = await _edgeDetectionPreProcessingProvider.Process(_commonImageSource.GetImage(txtImageKey.Text));

            _commonImageSource.SetImage(String.Format("T_ÉLEF", txtImageKey.Text), image);
        }

        private async void btnCommonPreProcess_Click(object sender, EventArgs e)
        {
            var image = await _commonRainyImagePreProcessingProvider.Process(_commonImageSource.GetImage(txtImageKey.Text));

            _commonImageSource.SetImage(String.Format("T_EF", txtImageKey.Text), image);
        }

        private async void btnDetectWithMorph_Click(object sender, EventArgs e)
        {
            var result = await _morphService.Process(_commonImageSource.GetImage(txtImageKey.Text));

            _commonImageSource.SetImage(String.Format("T_MORPH", txtImageKey.Text), result.OriginalImageWithRainDropAreas);

            MessageBox.Show(String.Format("Detektált esőcseppek száma: {0}", result.RainDropCount));
        }

        private async void btnDetectWithEdgeDetection_Click(object sender, EventArgs e)
        {
            var result = await _edgeDetectionService.Process(_commonImageSource.GetImage(txtImageKey.Text));

            _commonImageSource.SetImage(String.Format("T_EDGE", txtImageKey.Text), result.OriginalImageWithRainDropAreas);

            MessageBox.Show(String.Format("Detektált esőcseppek száma: {0}", result.RainDropCount));
        }
    }
}
