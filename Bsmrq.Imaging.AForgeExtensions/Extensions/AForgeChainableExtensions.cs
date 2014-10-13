using System.Drawing;
using AForge.Imaging.Filters;

namespace Bsmrq.Imaging.AForgeExtensions.Extensions
{
    /// <summary>
    /// Chainable methods to AForge image classes to make the imaging much more fun.
    /// </summary>
    public static class AForgeChainableExtensions
    {
        public static Bitmap ApplyGrayscale(this Bitmap image)
        {
            return new GrayscaleBT709().Apply(image);
        }

        public static Bitmap ApplyThreshold(this Bitmap image, int threshold)
        {
            return new Threshold(threshold).Apply(image);
        }
    }
}
