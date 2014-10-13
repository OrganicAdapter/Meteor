using DSP.RainDetector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSP.RainDetector
{
    public static class Constants
    {
        public static class ImageDetailedKeys
        {
            public static class SourceImage
            {
                public static readonly IDetailedKey Latest = new DetailedKey { Key = "Source.Latest", Description = "Latest source image" };

                public static readonly IDetailedKey BeforeLatest = new DetailedKey { Key = "Source.BeforeLatest", Description = "Image before the lates." };
            }
            public static class ResultImage
            {
                public static readonly IDetailedKey FinalImage = new DetailedKey { Key = "Source.Latest", Description = "Final image" };
            }

            public static class PreprocessedImage
            {
                public static readonly IDetailedKey Resized = new DetailedKey { Key = "Preprocessed.Resized", Description = "Resized image" };

                public static readonly IDetailedKey Median = new DetailedKey { Key = "Preprocessed.Median", Description = "Median filter applied" };

                public static readonly IDetailedKey Grayscale = new DetailedKey { Key = "Preprocessed.Grayscale", Description = "Grayscale image" };

                public static readonly IDetailedKey AdaptiveSmooth = new DetailedKey { Key = "Preprocessed.AdaptiveSmooth", Description = "Adaptive smoothed image" };

                public static readonly IDetailedKey Canny = new DetailedKey { Key = "Preprocessed.Canny", Description = "Canny edge detection result" };

                public static readonly IDetailedKey Threshold = new DetailedKey { Key = "Preprocessed.Threshold", Description = "Thresholded image" };
            }
        }

        public static class ImagePropertyDetailedKeys
        {
            public static class RainDetectionResult
            {
                public static readonly IDetailedKey RaindropCount = new DetailedKey { Key = "RainDetectionResult.RaindropCount", Description = "Raindrop count" };
            }
        }
    }
}
