using MSSCV.RainDetector.Models;

namespace MSSCV.RainDetector.Constants
{
    public static class PropertyKeys
    {
        public static class RainDetectionResult
        {
            public static readonly IDescriptedKey RaindropCount = new DescriptedKey { Key = "RainDetectionResult.RaindropCount", Description = "Raindrop count" };
        }

        public static class RainDetectionTest
        {
            public static readonly IDescriptedKey FalsePositives = new DescriptedKey { Key = "RainDetectionTest.FalsePositives", Description = "False positives" };

            public static readonly IDescriptedKey FalseNegatives = new DescriptedKey { Key = "RainDetectionTest.FalseNegatives", Description = "False negatives" };

            public static readonly IDescriptedKey Matches = new DescriptedKey { Key = "RainDetectionTest.Matches", Description = "Matches" };
        }
    }
}
