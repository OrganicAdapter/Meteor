using System.Collections.Generic;
using System.Drawing;

namespace DSP.RainDetector.Models
{
    /// <summary>
    /// Context of a rain detection containing properties of the detection process.
    /// </summary>
    public interface IRainDetectionContext
    {
        /// <summary>
        /// Original image used as the source image of all the filters implemented.
        /// </summary>
        Bitmap OriginalImage { get; set; }

        /// <summary>
        /// The final image containing the raindrops with rectangles around.
        /// </summary>
        Bitmap FinalImage { get; set; }

        /// <summary>
        /// Image after the preprocessing phase. Usually it has the raindrops clearly visible.
        /// </summary>
        Bitmap PreprocessedImage { get; set; }

        /// <summary>
        /// Count of the detected raindrops.
        /// </summary>
        int RaindropCount { get; set; }

        /// <summary>
        /// History containing the algorithms applied on the image.
        /// </summary>
        IList<string> History { get; set; }
    }


    public class RainDetectionContext : IRainDetectionContext
    {
        public Bitmap OriginalImage { get; set; }

        public Bitmap FinalImage { get; set; }

        public Bitmap PreprocessedImage { get; set; }

        public int RaindropCount { get; set; }

        public IList<string> History { get; set; }


        public RainDetectionContext()
        {
            History = new List<string>();
        }
    }
}
