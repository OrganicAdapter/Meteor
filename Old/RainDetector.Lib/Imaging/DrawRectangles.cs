using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace RainDetector.Lib.Imaging
{
    public partial class DrawRectangles
    {
        private object lockObject = new object();
        private Stopwatch stopWatch = new Stopwatch();
        private byte[] lookupTable;
        private DateTime timeStamp;
        private Bitmap image;
        private BitmapData bmData;
        private int stride;
        private IntPtr Scan0;
        private int nWidth, nHeight, nOffset;
        private Rectangle[] _rectangles;


        public DrawRectangles()
        {
            _rectangles = Enumerable.Empty<Rectangle>().ToArray();
        }

        public DrawRectangles(Rectangle[] rectangles)
        {
            _rectangles = rectangles;
        }

        public Bitmap Apply(Bitmap source)
        {
            image = source;
            timeStamp = DateTime.Now.ToLocalTime();

            Draw();

            return image;
        }

        private void Draw()
        {
            nWidth = image.Width;
            nHeight = image.Height;
            bmData = image.LockBits(new Rectangle(0, 0, nWidth, nHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            stride = bmData.Stride;
            Scan0 = bmData.Scan0;

            var pixelFormat = image.PixelFormat;

            lock (lockObject)
            {

                unsafe
                {
                    var p = (byte*)(void*)Scan0;

                    nOffset = stride - nWidth * 3;

                    for (int y = 0; y < nHeight; ++y)
                    {
                        for (int x = 0; x < nWidth; ++x)
                        {
                            foreach (var rectangle in _rectangles)
                            {
                                var left = rectangle.Left;
                                var right = rectangle.Right;
                                var top = rectangle.Top;
                                var bottom = rectangle.Bottom;

                                if (((x == left || x == right) && y >= top && y <= bottom)
                                    || ((y == top || y == bottom) && x >= left && x <= right))
                                    
                                {
                                    p[0] = 0;
                                    p[1] = 255;
                                    p[2] = 255;
                                }
                            }
                            p += 3;
                        }
                        p += nOffset;
                    }

                }

                image.UnlockBits(bmData);
            }
        }
    }
}
