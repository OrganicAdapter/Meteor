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
    public class CloudDetectorService : ISubProcessService
    {
        private int skylower;
        private int cloudupper;


        /// <summary>
        /// Sets up group limits.
        /// </summary>
        /// <param name="lower">Lower saturation value of the sky</param>
        /// <param name="upper">Upper saturation value of clouds</param>
        public void SetValues(int lower, int upper)
        {
            skylower = lower;
            cloudupper = upper;
        } 

        /// <summary>
        /// Creates thresholded image for cloud detection in place.
        /// </summary>
        /// <param name="input">Saturated, blured image</param>
        public async Task Execute(Bitmap input)
        {
            await Task.Factory.StartNew(() =>
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
                            if (p[0] < cloudupper)
                            {
                                //Clouds
                                p[0] = 255;
                                p[1] = 255;
                                p[2] = 255;
                            }
                            else if (p[0] <= skylower && p[0] >= cloudupper)
                            {
                                //Not defined
                                p[0] = 0;
                                p[1] = 255;
                                p[2] = 0;
                            }
                            else
                            {
                                //Sky
                                p[0] = 255;
                                p[1] = 0;
                                p[2] = 0;
                            }

                            p += 3;
                        }
                    }

                    input.UnlockBits(bmData);
                });
        }
    }
}
