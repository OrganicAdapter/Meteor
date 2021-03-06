﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSCVLib.Interfaces
{
    public delegate void SubresultAvailableEventHandler(object sender, string result);

    public interface IImageProcessService
    {
        /// <summary>
        /// Process the image and return the result as a string.
        /// </summary>
        /// <param name="image"> List of input images. </param>
        /// <returns> Result of the image processing. </returns>
        Task<string> ProcessImage(List<Bitmap> inputList);

        /// <summary>
        /// Fires if any subresult is available and returns it as a string.
        /// </summary>
        event SubresultAvailableEventHandler SubresultAvailableEvent;
    }
}
