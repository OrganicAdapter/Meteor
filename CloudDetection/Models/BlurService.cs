﻿using AForge.Imaging.Filters;
using MSSCVLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDetection.Models
{
    public class BlurService : ISubProcessService
    {
        /// <summary>
        /// Blur the image using AForge Blur algorythm in place.
        /// </summary>
        /// <param name="input">Original image</param>
        public async Task Execute(Bitmap input)
        {
            await Task.Factory.StartNew(() =>
                {
                    try
                    {
                        var blur = new Blur();
                        blur.Threshold = 0;
                        blur.Divisor = 20;
                        blur.ApplyInPlace(input);
                    }

                    catch
                    { 
                        
                    }
                });
        }
    }
}
