using System.Drawing;

namespace RainDetector.Lib.Models
{
    public class RainDetectionResult
    {
        public Bitmap PreProcessedImage { get; set; }
        public Bitmap MaskedImage { get; set; }
        public Bitmap BlobDetectedImage { get; set; }
        public Bitmap FilteredBlobDetectedImage { get; set; }
        public Bitmap RaindropDetectedImage { get; set; }
        public int BlobCount { get; set; }
        public int RaindropCount { get; set; }
        public bool IsRainy { get; set; }
        public int FilteredBlobCount { get; set; }
        public Bitmap OriginalHistogram { get; set; }
        public Bitmap AverageHistogram { get; set; }
    }
}
