using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace AForge.Math
{
    public static class HistogramExtensions
    {
        /// <summary>
        /// Returns a bitmap filled with histogram chart, which is 256 width.
        /// </summary>
        /// <param name="histogram">Histogram object</param>
        /// <param name="maxHeight">Maximum height of the result bitmap</param>
        public static Bitmap GetBitmap(this Histogram histogram, int maxHeight)
        {
            var b = new Bitmap(256, maxHeight);

            int max = histogram.Values.Max();
            double val = (double)maxHeight / max;

            var calculatedValues = new int[256];

            for (var i = 0; i<256; i++)
            {
                calculatedValues[i] = (int)System.Math.Ceiling((histogram.Values[i] * val));
            }

            BitmapData bmData = b.LockBits(new Rectangle(0, 0, 256, maxHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            var scan0 = bmData.Scan0;

            unsafe
            {
                var p = (byte*)(void*)scan0;

                int nOffset = stride - 256 * 3;

                for (int y = 0; y < maxHeight; ++y)
                {
                    for (int x = 0; x < 256; x++)
                    {
                            if (calculatedValues[x] < (maxHeight - y))
                            {
                                p[0] = p[1] = p[2] = 255;
                            }
                            else
                            {
                                p[0] = p[1] = p[2] = 0;
                            }

                            p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return b;
        }
    }
}
