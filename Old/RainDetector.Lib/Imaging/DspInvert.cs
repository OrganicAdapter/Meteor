using AForge.Imaging.Filters;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace RainDetector.Lib.Imaging
{
    public static class DspInvert
    {
        public const string Name = "Invertálás";
        private static Stopwatch stopWatch = new Stopwatch();
        private static Bitmap image;
        private static BitmapData bmData;
        private static int stride;
        private static int size;
        private static IntPtr Scan0;
        private static byte[] lookupTable;
        private static int nWidth, nHeight;

        public static byte[] LookupTable
        {
            get
            {
                return lookupTable;
            }
        }

        internal static void FillLookupTable()
        {
            lookupTable = new byte[256];

            Parallel.For(0, 256, i =>
            {
                lookupTable[i] = (byte)(~((byte)i));
            });
        }

        public static Bitmap Apply(Bitmap source)
        {
            image = new Bitmap(source);

            Invert_XOR();

            return image;
        }

        private static void Invert_XOR()
        {
            nWidth = image.Width;
            nHeight = image.Height;
            bmData = image.LockBits(new Rectangle(0, 0, nWidth, nHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            stride = bmData.Stride;
            Scan0 = bmData.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                size = nHeight * nWidth;

                for (int i = 0; i < size; ++i)
                {
                    //p[0] = (byte)~(p[0]);
                    //p[0] = lookupTable[p[0]];
                    //p[1] = lookupTable[p[1]];
                    //p[2] = lookupTable[p[2]];
                    //p++;
                    p[0] = (byte)~p[0];
                    p[1] = (byte)~p[1];
                    p[2] = (byte)~p[2];
                    p += 3;
                }
            }

            image.UnlockBits(bmData);
        }
    }
}
