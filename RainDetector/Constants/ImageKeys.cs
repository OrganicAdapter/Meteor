using MSSCV.RainDetector.Models;

namespace MSSCV.RainDetector.Constants
{
    public static class ImageKeys
    {
        public static class SourceImages
        {
            public static readonly IDescriptedKey Latest = new DescriptedKey { Key = "SourceImages.Latest", Description = "Latest source image" };
        }
        public static class ResultImages
        {
            public static readonly IDescriptedKey ImageWithRaindropRegions = new DescriptedKey { Key = "ResultImages.ImageWithRaindropRegions", Description = "Final image with raindrop regions" };
        }

        public static class ProcessedImages
        {
            public static readonly IDescriptedKey Resized = new DescriptedKey { Key = "ProcessedImages.Resized", Description = "Resized image" };

            public static readonly IDescriptedKey Median = new DescriptedKey { Key = "ProcessedImages.Median", Description = "Median filter applied" };

            public static readonly IDescriptedKey Grayscale = new DescriptedKey { Key = "ProcessedImages.Grayscale", Description = "Grayscale image" };

            public static readonly IDescriptedKey AdaptiveSmooth = new DescriptedKey { Key = "ProcessedImages.AdaptiveSmooth", Description = "Adaptive smoothed image" };

            public static readonly IDescriptedKey Canny = new DescriptedKey { Key = "ProcessedImages.Canny", Description = "Canny edge detection result" };

            public static readonly IDescriptedKey Threshold = new DescriptedKey { Key = "ProcessedImages.Threshold", Description = "Thresholded image" };

            public static readonly IDescriptedKey ContrastStretch = new DescriptedKey { Key = "ProcessedImages.ContrastStretch", Description = "ContrastStretch image" };

            public static readonly IDescriptedKey MorphReconstruction = new DescriptedKey { Key = "ProcessedImages.MorphReconstruction", Description = "MorphReconstruction image" };

            public static readonly IDescriptedKey AddedImages = new DescriptedKey { Key = "ProcessedImages.AddedImages", Description = "Added images" };
        }

        public static class TestImages
        {
            public static readonly IDescriptedKey TestRegions = new DescriptedKey { Key = "TestImages.TestRegions", Description = "Test regions" };

            public static readonly IDescriptedKey TestResults = new DescriptedKey { Key = "TestImages.TestResults", Description = "Test results" };
        }
    }
}
