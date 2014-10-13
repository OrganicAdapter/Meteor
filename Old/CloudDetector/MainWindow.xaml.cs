using CloudDetectorDLL.ViewModel;
using DarkSkyProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CloudDetector
{
    public partial class MainWindow : Window
    {
        public MainViewModel Main { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += WindowLoaded;
        }

        public MainWindow(ICommonImageSource imageSource, string filename)
        {
            InitializeComponent();
            this.Loaded += WindowLoaded;

            MainViewModel.Instance.FakeOpen(imageSource.CurrentImage, filename);
        }

        void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Main = MainViewModel.Instance;
            this.DataContext = Main;
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            Main.Open();
        }

        private void GetSaturation(object sender, RoutedEventArgs e)
        {
            Main.GetSaturation();
        }

        private void GetClouds(object sender, RoutedEventArgs e)
        {
            Main.GetClouds();
        }

        private void GetCloudiness(object sender, RoutedEventArgs e)
        {
            Main.GetCloudiness();
        }

        private void GetCloudType(object sender, RoutedEventArgs e)
        {
            Main.GetCloudType();
        }

        private void SetGauss(object sender, RoutedEventArgs e)
        {
            //Main.SetGauss(20);
            Main.SetGauss(1);
        }

        private void GetFullDetection(object sender, RoutedEventArgs e)
        {
            Main.GetFullDetection();
        }

        private void ManualConfiguration(object sender, RoutedEventArgs e)
        {
            var conf = new ConfigurationWindow();
            conf.ShowDialog();       
        }

        private void AutoConfiguration(object sender, RoutedEventArgs e)
        {
            Main.GetAutoConfiguration();
        }

        private void RunTest(object sender, RoutedEventArgs e)
        {
            Main.RunTest();
        }

        private void SequenceStats(object sender, RoutedEventArgs e)
        {
            Main.OpenSequence();
        }
    }
}
