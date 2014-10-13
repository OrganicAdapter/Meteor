using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace AForge.Math
{
    public static class HistogramExtensions
    {
        /// <summary>
        /// Returns with a 256 width bitmap filled with histogram chart.
        /// </summary>
        /// <param name="histogram">Histogram object</param>
        /// <param name="maxHeight">Maximum height of the result bitmap</param>
        public static Bitmap GetHistogramChartBitmap(this Histogram histogram, int maxHeight)
        {
            var b = new Bitmap(256, maxHeight);

            var max = histogram.Values.Max();
            var val = (double)maxHeight / max;

            var calculatedValues = new int[256];

            for (var i = 0; i<256; i++)
            {
                calculatedValues[i] = (int)System.Math.Ceiling((histogram.Values[i] * val));
            }

            var bmData = b.LockBits(new Rectangle(0, 0, 256, maxHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            var stride = bmData.Stride;
            var scan0 = bmData.Scan0;

            unsafe
            {
                var p = (byte*)(void*)scan0;

                var nOffset = stride - 256 * 3;

                for (var y = 0; y < maxHeight; ++y)
                {
                    for (var x = 0; x < 256; x++)
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
