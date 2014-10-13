using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDetectorDLL.Model
{
    public class NightDetector
    {
        private static int avarage;
        private static float sum_avg;

        public static bool GetNight(Bitmap bit)
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
                    avarage = (p[0] + p[1] + p[2]) / 3;
                    sum_avg += avarage;

                    p += 3;
                }

                sum_avg = sum_avg / size;
            }

            b.UnlockBits(bmData);

            if (sum_avg <= 100)
                return true;
            else
                return false;
        }
    }
}
