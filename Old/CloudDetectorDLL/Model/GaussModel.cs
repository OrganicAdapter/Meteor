using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDetectorDLL.Model
{
    public class GaussModel
    {
        public static Bitmap GetGauss(Bitmap b)
        {
            try
            {
                Bitmap bit = new Bitmap(b);

                BitmapData bmData = bit.LockBits(new Rectangle(0, 0, bit.Width, bit.Height),
                                    ImageLockMode.ReadWrite,
                                    PixelFormat.Format24bppRgb);
                int stride = bmData.Stride;
                System.IntPtr Scan = bmData.Scan0;

                BitmapData bmData2 = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
                                    ImageLockMode.ReadWrite,
                                    PixelFormat.Format24bppRgb);
                int stride2 = stride * 2;
                System.IntPtr Scan2 = bmData2.Scan0;

                unsafe
                {
                    byte* p = (byte*)(void*)Scan2;
                    byte* p2 = (byte*)(void*)Scan;
                    int size = (b.Width - 2) * (b.Height - 2);

                    for (int i = 0; i < size; i++)
                    {
                        p2[5 + stride] = (byte)((p[2] + (p[5] << 1) + p[8] + (p[2 + stride] << 1) + (p[5 + stride] << 2) + (p[8 + stride] << 1) + p[2 + stride2] + (p[5 + stride2] << 1) + p[8 + stride2]) >> 4);
                        p2[4 + stride] = (byte)((p[1] + (p[4] << 1) + p[7] + (p[1 + stride] << 1) + (p[4 + stride] << 2) + (p[7 + stride] << 1) + p[1 + stride2] + (p[4 + stride2] << 1) + p[7 + stride2]) >> 4);
                        p2[3 + stride] = (byte)((p[0] + (p[3] << 1) + p[6] + (p[0 + stride] << 1) + (p[3 + stride] << 2) + (p[6 + stride] << 1) + p[0 + stride2] + (p[3 + stride2] << 1) + p[6 + stride2]) >> 4);

                        p += 3;
                        p2 += 3;
                    }
                }

                b.UnlockBits(bmData2);
                bit.UnlockBits(bmData);

                return bit;
            }

            catch (OutOfMemoryException)
            {
                return b;
            }

            catch (NullReferenceException)
            {
                return b;
            }

            catch (ArgumentException)
            {
                return b;
            }
        }

        public static Bitmap GetGaussAForge(Bitmap b)
        {
            var bit = new Bitmap(b);

            var blur = new Blur();
            blur.Threshold = 0;
            blur.Divisor = 20;
            var a = blur.Apply(bit);

            bit.Dispose();
            b.Dispose();

            return a;
        }
    }
}
