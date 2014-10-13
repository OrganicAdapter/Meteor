using AForge.Imaging.Filters;
using CloudDetectorDLL.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDetectorDLL.Model
{
    public class AutoConfigurationModel
    {
        private static int GetOtsuThreshold(Bitmap b)
        {
            var otsu = new OtsuThreshold();

            var threshold = otsu.ThresholdValue;

            return threshold;
        }

        public static void GetThresholdLevels_1(Bitmap b)
        {
            var Main = MainViewModel.Instance;

            var threshold = GetOtsuThreshold(b);

            Main.CloudUpper = threshold - 100;
            Main.SkyLower = threshold - 70;

            Main.SaveConfiguration();
        }

        public static void GetThresholdLevels_2(Bitmap b)
        {
            var Main = MainViewModel.Instance;

            var threshold = GetOtsuThreshold(b);

            Main.CloudUpper = threshold - 30;
            Main.SkyLower = threshold + 100;

            Main.SaveConfiguration();
        }
    }
}
