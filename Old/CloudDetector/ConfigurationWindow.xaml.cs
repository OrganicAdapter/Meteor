using CloudDetectorDLL.ViewModel;
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
using System.Windows.Shapes;

namespace CloudDetector
{
    public partial class ConfigurationWindow : Window
    {
        public ConfigurationViewModel Configuration { get; set; }

        public ConfigurationWindow()
        {
            InitializeComponent();
            this.Loaded += WindowLoaded;
            this.Closing += WindowClosing;
        }

        void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainViewModel.Instance.SaveConfiguration();
        }

        void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var Main = MainViewModel.Instance;

            Configuration = ConfigurationViewModel.Instance;
            Configuration.CloudUpper = Main.CloudUpper;
            Configuration.SkyLower = Main.SkyLower;

            this.DataContext = Configuration;
        }

        private void OpenCumulus(object sender, RoutedEventArgs e)
        {
            Configuration.OpenCumulus();
        }

        private void OpenStratus(object sender, RoutedEventArgs e)
        {
            Configuration.OpenStratus();
        }

        private void OpenMixed(object sender, RoutedEventArgs e)
        {
            Configuration.OpenMixed();
        }

        private void GetThresholdImages(object sender, RoutedPropertyChangedEventArgs<double> e)
        {            
            if (Configuration.SkyLower < Configuration.CloudUpper)
                Configuration.SkyLower = Configuration.CloudUpper;            

            Configuration.GetThresholdImages();
        }
    }
}
