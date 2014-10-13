using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDetectorDLL.Model
{
    public class CloudDetectorModel
    {
        public static Bitmap GetClouds_1(Bitmap bit, int cloudupper, int skylower)
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
                    if (p[0] < cloudupper)
                    {
                        //Felhő
                        p[0] = 255;
                        p[1] = 255;
                        p[2] = 255;
                    }
                    else if (p[0] <= skylower && p[0] >= cloudupper)
                    {
                        //Nem meghatározott
                        p[0] = 0;
                        p[1] = 255;
                        p[2] = 0;
                    }
                    else
                    {
                        //Ég
                        p[0] = 255;
                        p[1] = 0;
                        p[2] = 0;
                    }
                    //else
                    //{
                    //    //Egyéb
                    //    p[0] = 0;
                    //    p[1] = 0;
                    //    p[2] = 255;
                    //}

                    p += 3;
                }
            }

            b.UnlockBits(bmData);

            return b;
        }

        public static Bitmap GetClouds_2(Bitmap bit, int cloudupper, int skylower)
        {
            Bitmap b = new Bitmap(bit);

            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            //cloudupper = 50;
            //skylower = 150;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int size = b.Height * b.Width;

                for (int i = 0; i < size; ++i)
                {
                    if (p[0] < cloudupper)
                    {
                        //Felhő
                        p[0] = 255;
                        p[1] = 255;
                        p[2] = 255;
                    }
                    else if (p[0] <= skylower && p[0] >= cloudupper)
                    {
                        //Nem meghatározott
                        p[0] = 0;
                        p[1] = 255;
                        p[2] = 0;
                    }
                    else
                    {
                        //Ég
                        p[0] = 255;
                        p[1] = 0;
                        p[2] = 0;
                    }
                    //else
                    //{
                    //    //Egyéb
                    //    p[0] = 0;
                    //    p[1] = 0;
                    //    p[2] = 255;
                    //}

                    p += 3;
                }
            }

            b.UnlockBits(bmData);
            bit.Dispose();

            return b;
        }

        public static int GetCloudiness(Bitmap bit)
        {
            var clouds = GetCloudNumber(bit);
            var size = bit.Width * bit.Height;
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
                clouds = GetCloudNumberPro(bit);
                okta = (int)Math.Round(clouds / eight);

                if (okta == 8 && diff >= size / 1000)
                    return 7;

                return okta;
            }
        }

        private static double GetCloudNumber(Bitmap bit)
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

        private static double GetCloudNumberPro(Bitmap bit)
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
