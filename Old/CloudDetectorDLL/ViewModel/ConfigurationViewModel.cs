using CloudDetectorDLL.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudDetectorDLL.ViewModel
{
    public class ConfigurationViewModel : ModelBase
    {
        private static ConfigurationViewModel _instance;
        public static ConfigurationViewModel Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new ConfigurationViewModel();

                return _instance;
            }
        }


        private Bitmap _cumulusimage;
        public Bitmap CumulusImage
        {
            get { return _cumulusimage; }
            set { _cumulusimage = value; OnPropertyChanged("CumulusImage"); }
        }

        private Bitmap _stratusimage;
        public Bitmap StratusImage
        {
            get { return _stratusimage; }
            set { _stratusimage = value; OnPropertyChanged("StratusImage"); }
        }

        private Bitmap _mixedimage;
        public Bitmap MixedImage
        {
            get { return _mixedimage; }
            set { _mixedimage = value; OnPropertyChanged("MixedImage"); }
        }

        private Bitmap _thresholdcumulusimage;
        public Bitmap ThresholdCumulusImage
        {
            get { return _thresholdcumulusimage; }
            set { _thresholdcumulusimage = value; OnPropertyChanged("ThresholdCumulusImage"); }
        }

        private Bitmap _thresholdstratusimage;
        public Bitmap ThresholdStratusImage
        {
            get { return _thresholdstratusimage; }
            set { _thresholdstratusimage = value; OnPropertyChanged("ThresholdStartusImage"); }
        }

        private Bitmap _thresholdmixedimage;
        public Bitmap ThresholdMixedImage
        {
            get { return _thresholdmixedimage; }
            set { _thresholdmixedimage = value; OnPropertyChanged("ThresholdMixedImage"); }
        }

        private int _cloudupper;
        public int CloudUpper
        {
            get { return _cloudupper; }
            set { _cloudupper = value; OnPropertyChanged("CloudUpper"); }
        }

        private int _skylower;
        public int SkyLower
        {
            get { return _skylower; }
            set { _skylower = value; OnPropertyChanged("SkyLower"); }
        }



        private Bitmap ResizeImage(Bitmap image)
        {
            double help = image.Height / 200;

            image = new Bitmap(image, (int)(image.Width / help), (int)(image.Height / help));

            return image;
        }

        public void OpenCumulus()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var img = new Bitmap(openFileDialog.FileName);
                CumulusImage = ResizeImage(img);
            }

            GetThresholdImages();
        }

        public void OpenStratus()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var img = new Bitmap(openFileDialog.FileName);
                StratusImage = ResizeImage(img);
            }

            GetThresholdImages();
        }

        public void OpenMixed()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var img = new Bitmap(openFileDialog.FileName);
                MixedImage = ResizeImage(img);
            }

            GetThresholdImages();
        }

        public void GetThresholdImages()
        {
            var Main = MainViewModel.Instance;

            Main.CloudUpper = CloudUpper;
            Main.SkyLower = SkyLower;

            if (CumulusImage != null)
            {
                Main.OriginalImage = CumulusImage;
                Main.GetSaturation();
                Main.SetGauss(5);
                Main.GetClouds();

                ThresholdCumulusImage = Main.ThresholdImage;
            }

            if (StratusImage != null)
            {
                Main.OriginalImage = StratusImage;
                Main.GetSaturation();
                Main.SetGauss(5);
                Main.GetClouds();

                ThresholdStratusImage = Main.ThresholdImage;
            }

            if (MixedImage != null)
            {
                Main.OriginalImage = MixedImage;
                Main.GetSaturation();
                Main.SetGauss(5);
                Main.GetClouds();

                ThresholdMixedImage = Main.ThresholdImage;
            }

            Main.OriginalImage = null;
            Main.ThresholdImage = null;
            Main.SaturationImage = null;
        }
    }
}
