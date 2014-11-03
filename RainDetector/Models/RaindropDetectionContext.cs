using MSSCV.RainDetector.Constants;
using System.Collections.Generic;
using System.Drawing;

namespace MSSCV.RainDetector.Models
{
    /// <summary>
    /// Context of a rain detection containing properties of the detection process.
    /// </summary>
    public interface IRaindropDetectionContext
    {
        /// <summary>
        /// History describing the steps during the raindrop detection process.
        /// </summary>
        IList<string> History { get; set; }

        /// <summary>
        /// Original images used as the source image of all the filters implemented.
        /// </summary>
        IDictionary<IDescriptedKey, Bitmap> Images { get; set; }

        /// <summary>
        /// Count of the detected raindrops.
        /// </summary>
        int RaindropCount { get; set; }

        /// <summary>
        /// Regions of the raindrops on the image.
        /// </summary>
        IList<Rectangle> RaindropRegions { get; set; }

        /// <summary>
        /// Custom properties (eg. results) of the detection process.
        /// </summary>
        IDictionary<IDescriptedKey, object> CustomProperties { get; set; }
    }

    public class RaindropDetectionContext : IRaindropDetectionContext
    {
        public RaindropDetectionContext()
        {
            History = new List<string>();
            Images = new Dictionary<IDescriptedKey, Bitmap>();
            CustomProperties = new Dictionary<IDescriptedKey, object>();
        }

        public IList<string> History { get; set; }

        public IDictionary<IDescriptedKey, Bitmap> Images { get; set; }

        public IList<Rectangle> RaindropRegions { get; set; }

        public IDictionary<IDescriptedKey, object> CustomProperties { get; set; }

        public int RaindropCount
        {
            get
            {
                return CustomProperties.ContainsKey(PropertyKeys.RainDetectionResult.RaindropCount) ?
                    (int)CustomProperties[PropertyKeys.RainDetectionResult.RaindropCount] : 0;
            }
            set
            {
                CustomProperties[PropertyKeys.RainDetectionResult.RaindropCount] = value;
            }
        }
    }
}