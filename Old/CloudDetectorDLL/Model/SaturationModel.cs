using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDetectorDLL.Model
{
    public class SaturationModel
    {
        static byte red, green, blue;
        static byte min, max;
        static byte sum, diff;
        static byte intens;

        public static Bitmap GetSaturation_1(Bitmap bit)
        {
            Bitmap b = new Bitmap(bit);

            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int size = b.Height * b.Width;

                for (int i = 0; i < size; ++i)
                {
                    blue = p[0];
                    green = p[1];
                    red = p[2];

                    if (blue > green)
                        min = green;
                    else
                        min = blue;

                    if (red < min)
                        min = red;

                    if (red == 0 && green == 0 && blue == 0)
                        red = 1;

                    p[0] = p[1] = p[2] = (byte)(255 * (1 - (3 / (float)(red + green + blue)) * min));

                    p += 3;
                }
            }

            //bit.Dispose();
            b.UnlockBits(bmData);

            return b;
        }

        public static Bitmap GetSaturation_2(Bitmap bit)
        {
            Bitmap b = new Bitmap(bit);

            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int size = b.Height * b.Width;

                for (int i = 0; i < size; ++i)
                {
                    blue = p[0];
                    green = p[1];
                    red = p[2];

                    if ((red < 0 && green < 0 && blue < 0) || (red > 255 || green > 255 || blue > 255))
                        return null;

                    if (green == blue)
                    {
                        if (blue < 255)
                            blue = (byte)(blue + 1);
                        else
                            blue = (byte)(blue - 1);
                    }

                    max = Math.Max(red, blue);
                    max = Math.Max(max, green);
                    min = Math.Min(red, blue);
                    min = Math.Min(min, green);
                    sum = (byte)(min + max);
                    diff = (byte)(max - min);

                    intens = (byte)(sum / 2);

                    if (intens < 128)
                        p[0] = p[1] = p[2] = (byte)(255 * ((float)diff / sum));
                    else
                        p[0] = p[1] = p[2] = (byte)(255 * ((float)diff / (510 - sum)));

                    p += 3;
                }
            }

            b.UnlockBits(bmData);

            return b;
        }
    }
}
