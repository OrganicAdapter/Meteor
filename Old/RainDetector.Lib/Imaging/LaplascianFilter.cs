using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;

namespace RainDetector.Lib.Imaging
{
    public class LaplascianFilter : IFilter
    {
        public const string Name = "Laplascian";
        private object lockObject = new object();
        private Stopwatch stopWatch = new Stopwatch();
        private DateTime timeStamp;
        private BitmapData bmData;
        private BitmapData bmDataSmoothed;
        private int stride, stride2;
        private int nOffset;
        private IntPtr Scan0Smoothed, Scan0;
        private int nWidth, nHeight;
        private Bitmap image;
        private Bitmap filteredImage;

        public Bitmap Apply(Bitmap source)
        {
            image = source;

            Laplace();

            var result = filteredImage;
            return result;
        }

        private void Laplace()
        {
            filteredImage = new Bitmap(image.Width, image.Height);
            bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                ImageLockMode.ReadWrite,
                                PixelFormat.Format24bppRgb);
            bmDataSmoothed = filteredImage.LockBits(new Rectangle(0, 0, filteredImage.Width, filteredImage.Height),
                               ImageLockMode.ReadWrite,
                               PixelFormat.Format24bppRgb);

            stride = bmData.Stride;
            stride2 = stride * 2;

            Scan0Smoothed = bmDataSmoothed.Scan0;
            Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0Smoothed;
                byte* pSrc = (byte*)(void*)Scan0;
                nOffset = stride - image.Width * 3;

                nWidth = image.Width - 2;
                nHeight = image.Height - 2;

                lock (lockObject)
                {

                    for (int y = 0; y < nHeight; ++y)
                    {
                        for (int x = 0; x < nWidth; ++x)
                        {
                            p[5 + stride] = (byte)(pSrc[2] * -1 + pSrc[8] * -1 +
                                pSrc[5 + stride] * 4 +
                                pSrc[2 + stride2] * -1 + pSrc[8 + stride2] * -1 + 127);

                            p[4 + stride] = (byte)(pSrc[1] * -1 + pSrc[7] * -1 +
                                pSrc[4 + stride] * 4 +
                                pSrc[1 + stride2] * -1 + pSrc[7 + stride2] * -1 + 127);

                            p[3 + stride] = (byte)(pSrc[0] * -1 + pSrc[6] * -1 +
                                pSrc[3 + stride] * 4 +
                                pSrc[0 + stride2] * -1 + pSrc[6 + stride2] * -1 + 127);

                            //p[0] = p[1] = p[2] = greyScaleLookupTable[p[0] + p[1] + p[2]];

                            p += 3;
                            pSrc += 3;
                        }

                        p += nOffset + 6;
                        pSrc += nOffset + 6;
                    }
                }
            }

            image.UnlockBits(bmData);
            filteredImage.UnlockBits(bmDataSmoothed);
        }

        public void Apply(AForge.Imaging.UnmanagedImage sourceImage, AForge.Imaging.UnmanagedImage destinationImage)
        {
            throw new NotImplementedException();
        }

        public AForge.Imaging.UnmanagedImage Apply(AForge.Imaging.UnmanagedImage image)
        {
            throw new NotImplementedException();
        }

        public Bitmap Apply(BitmapData imageData)
        {
            throw new NotImplementedException();
        }
    }
}
