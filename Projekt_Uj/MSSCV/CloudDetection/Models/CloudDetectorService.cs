using MSSCVLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDetection.Models
{
    public class CloudDetectorService : ISubProcessService
    {
        public void Execute(Bitmap input)
        {
            //Bitmap b = new Bitmap(bit);

            //BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //int stride = bmData.Stride;
            //System.IntPtr Scan0 = bmData.Scan0;

            //unsafe
            //{
            //    byte* p = (byte*)(void*)Scan0;
            //    int size = b.Height * b.Width;

            //    for (int i = 0; i < size; ++i)
            //    {
            //        if (p[0] < cloudupper)
            //        {
            //            //Felhő
            //            p[0] = 255;
            //            p[1] = 255;
            //            p[2] = 255;
            //        }
            //        else if (p[0] <= skylower && p[0] >= cloudupper)
            //        {
            //            //Nem meghatározott
            //            p[0] = 0;
            //            p[1] = 255;
            //            p[2] = 0;
            //        }
            //        else
            //        {
            //            //Ég
            //            p[0] = 255;
            //            p[1] = 0;
            //            p[2] = 0;
            //        }
            //        //else
            //        //{
            //        //    //Egyéb
            //        //    p[0] = 0;
            //        //    p[1] = 0;
            //        //    p[2] = 255;
            //        //}

            //        p += 3;
            //    }
            //}

            //b.UnlockBits(bmData);

            //return b;
        }
    }
}
