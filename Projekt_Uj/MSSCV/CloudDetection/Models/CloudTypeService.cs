using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDetection.Models
{
    public class CloudTypeService
    {
        private int[] myList = new int[256];

        public string Execute(Bitmap original, Bitmap detected, int okta)
        {
            myList = new int[256];

            GetHistogram(original, detected);

            int count = 0;

            var size = original.Width * original.Height;

            foreach (var akt in myList)
                if (akt >= size / 1000000)
                    count++;

            if (okta < 7)
            {
                if (okta == 0)
                    return "Clear";

                if (count >= 130)
                    return "Cumulus";
                else
                {
                    if (okta == 1)
                        return "Cumulus";
                    else
                        return "Stratus";
                }
            }
            else
            {
                if (count >= 130)
                    return "Cumulus";
                else
                    return "Stratus";
            }
        }

        private void GetHistogram(Bitmap original, Bitmap detected)
        {
            BitmapData bmData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            BitmapData bmData2 = detected.LockBits(new Rectangle(0, 0, detected.Width, detected.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride2 = bmData2.Stride;
            System.IntPtr Scan2 = bmData2.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* p2 = (byte*)(void*)Scan2;

                for (int y = 0; y < original.Height; ++y)
                {
                    for (int x = 0; x < original.Width; x++)
                    {
                        if (p2[0] == 255 && p2[1] == 255 && p2[2] == 255)
                        {
                            p[0] = (byte)((p[0] + p[1] + p[2]) / 3);

                            myList[p[0]]++;
                        }

                        p += 3;
                        p2 += 2;
                    }
                }
            }

            original.UnlockBits(bmData);
            detected.UnlockBits(bmData2);
        }
    }
}
