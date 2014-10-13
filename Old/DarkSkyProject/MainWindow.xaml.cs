using System.Drawing;
using System.Windows.Forms;
using DarkSkyProject.ViewModels;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using RainDetector.Forms;
using DarkSkyProject.Common.Models;
using MessageBox = System.Windows.MessageBox;
using RainDetector.Lib.Services;

namespace DarkSkyProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainViewModel();

            DataContext = ViewModel;
        }

        private void FileOpen_Click(object sender, RoutedEventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image files|*.jpg;*.png";

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ViewModel.Common.CurrentImage = new Bitmap(ofd.FileName);

                    ViewModel.OpenedImageFileName = ofd.FileName;
                }
            }
        }

        private void DetectRaindrops_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Common.CurrentImage == null)
            {
                MessageBox.Show("Először nyisson meg egy képet!");
                return;
            }

            var commonImageSource = CommonImageSource.Instance;
            var commonRainyImagePreProcessingProvider = new CommonRainyImagePreProcessingProvider();
            var rectangleFilteringProvider = new RectangleFilteringProvider();
            var morphPreProcessingProvider = new MorphologicalReconstructionPreProcessingProvider();
            var morphService = new MorphologicalReconstructionMethodService(commonImageSource, commonRainyImagePreProcessingProvider, 
                rectangleFilteringProvider, morphPreProcessingProvider);
            var edgePreProcessingProvider = new EdgeDetectionPreProcessingProvider(commonRainyImagePreProcessingProvider);
            var edgeService = new EdgeDetectionMethodService(commonImageSource, edgePreProcessingProvider, rectangleFilteringProvider);

            //var rainDetectionForm = new DetectionSequenceForm(new RainDetectionService(new DefaultImagePreProcessingProvider()), CommonImageSource.Instance);
            var rainDetectionForm = new RainDetectorTestForm(commonImageSource,
                morphPreProcessingProvider,
                commonRainyImagePreProcessingProvider,
                edgePreProcessingProvider,
                morphService,
                edgeService);
            rainDetectionForm.Show();
        }

        private void DetectClouds_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Common.CurrentImage == null)
            {
                MessageBox.Show("Először nyisson meg egy képet!");
                return;
            }
            var cloudDetectionWindow = new CloudDetector.MainWindow(
                CommonImageSource.Instance,
                ViewModel.OpenedImageFileName);

            cloudDetectionWindow.Show();
        }
    }
}
