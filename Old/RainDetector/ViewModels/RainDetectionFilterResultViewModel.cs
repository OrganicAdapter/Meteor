using System;
using System.Drawing;

namespace RainDetector.ViewModels
{
    public class RainDetectionFilterResultViewModel
    {
        public Bitmap ResultImage { get; set; }
        public string FilterName { get; set; }
        public string FilterDetails { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
