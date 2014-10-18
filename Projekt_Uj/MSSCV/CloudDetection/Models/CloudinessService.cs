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
    public class CloudinessService
    {
        public int Execute(Bitmap input)
        {
            var clouds = GetCloudPercentageSimple(input);
            var size = input.Width * input.Height;
            var diff = size - clouds;

            var eight = size / 8;
            var okta = (int)Math.Round(clouds / eight);

            //Ha egy kis felhő van már 1, ha 1 kis lyuk van, már 7 okta
            //Képméret 100-ad és 1000-ed részét figyelem

            //if (okta == 0 && clouds >= size / 100)
            //    return 1;
            if (okta == 0 && clouds < size / 100)
                return 0;
            else if (okta == 0 && clouds >= size / 100)
                return 1;
            else if (okta == 8 && diff >= size / 1000)
                return 7;
            else
            {
                clouds = GetCloudPercentageAdvanced(input);
                okta = (int)Math.Round(clouds / eight);

                if (okta == 8 && diff >= size / 1000)
                    return 7;

                return okta;
            }
        }

        private double GetCloudPercentageSimple(Bitmap bit)
        {
            Bitmap b = new Bitmap(bit);

            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            double value = 0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int size = b.Height * b.Width;

                for (int i = 0; i < size; ++i)
                {
                    if (p[0] == 255 && p[1] == 255 && p[2] == 255)
                    {
                        value++;
                    }

                    p += 3;
                }
            }

            b.UnlockBits(bmData);
            b.Dispose();

            return value;
        }

        private double GetCloudPercentageAdvanced(Bitmap bit)
        {
            Bitmap b = new Bitmap(bit);

            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            double value = 0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int size = b.Height * b.Width;

                for (int i = 0; i < size; ++i)
                {
                    if (p[0] == 255 && p[1] == 255 && p[2] == 255)
                    {
                        value++;
                    }
                    else if (p[0] == 0 && p[1] == 255 && p[2] == 0)
                    {
                        value++;
                    }

                    p += 3;
                }
            }

            b.UnlockBits(bmData);
            b.Dispose();

            return value;
        }
    }
}
