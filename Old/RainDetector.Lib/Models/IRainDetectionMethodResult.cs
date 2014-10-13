using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainDetector.Lib.Models
{
    public interface IRainDetectionMethodResult
    {
        int RainDropCount { get; }

        Rectangle[] RainDropAreas { get; }

        Bitmap OriginalImageWithRainDropAreas { get; }
    }
}
