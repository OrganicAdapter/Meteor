using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RainDetector.Lib.Services
{
    public class CommonRainyImagePreProcessingProvider : IImageProcessingProvider
    {
        public async Task<System.Drawing.Bitmap> Process(System.Drawing.Bitmap image)
        {
            var median = new Median();
            var grayscale = new GrayscaleBT709();
            var adaptiveSmoothFilter = new AdaptiveSmoothing();

            var imageToProcess = image.Resize(640, 480);
            //var imageToProcess = image;

            imageToProcess = median.Apply(imageToProcess);
            imageToProcess = grayscale.Apply(imageToProcess);
            imageToProcess = adaptiveSmoothFilter.Apply(imageToProcess);

            return imageToProcess;
        }
    }
}
