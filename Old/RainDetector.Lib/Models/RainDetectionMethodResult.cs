using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainDetector.Lib.Models
{
    public class RainDetectionMethodResult : IRainDetectionMethodResult
    {
        private Rectangle[] _raindropAreas;
        private Bitmap _originalImageWithRainDropAreas;


        public int RainDropCount
        {
            get
            {
                return RainDropAreas.Length;
            }
        }

        public Rectangle[] RainDropAreas
        {
            get
            {
                return _raindropAreas;
            }
            set
            {
                _raindropAreas = value;
            }
        }

        public Bitmap OriginalImageWithRainDropAreas
        {
            get
            {
                return _originalImageWithRainDropAreas;
            }
            set
            {
                _originalImageWithRainDropAreas = value;
            }
        }
    }

}
