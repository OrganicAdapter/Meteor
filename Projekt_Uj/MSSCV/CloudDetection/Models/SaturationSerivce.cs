using MSSCVLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDetection.Models
{
    public class SaturationService : ISubProcessService
    {
        private static byte red, green, blue;
        private static byte min;

        public void Execute(Bitmap input)
        {
            BitmapData bmData = input.LockBits(new Rectangle(0, 0, input.Width, input.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int size = input.Height * input.Width;

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

            input.UnlockBits(bmData);
        }
    }
}
