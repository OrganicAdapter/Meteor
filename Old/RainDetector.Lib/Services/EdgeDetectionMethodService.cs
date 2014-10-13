using AForge.Imaging;
using DarkSkyProject.Common.Models;
using RainDetector.Lib.Imaging;
using RainDetector.Lib.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainDetector.Lib.Services
{
    public class EdgeDetectionMethodService : IRainDetectionMethodService
    {
        private readonly ICommonImageSource _commonImageSource;
        private readonly IImageProcessingProvider _preProcessingProvider;
        private readonly IRectangleFilteringProvider _rectangleFilterProvider;


        public EdgeDetectionMethodService(ICommonImageSource commonImageSource, IImageProcessingProvider preProcessingProvider,
            IRectangleFilteringProvider rectangleMergingProvider)
        {
            _commonImageSource = commonImageSource;
            _preProcessingProvider = preProcessingProvider;
            _rectangleFilterProvider = rectangleMergingProvider;
        }


        public async Task<IRainDetectionMethodResult> Process(Bitmap image)
        {
            var result = new RainDetectionMethodResult();

            var resizedImage = image.Resize(640, 480);

            var edgeDetectedResult = await _preProcessingProvider.Process(resizedImage);

            var rectangles = await edgeDetectedResult.GetBlobRectangles(image.Width / 4, image.Height / 32, image.Height / 4, image.Width / 32);

            var filteredRectangles = await _rectangleFilterProvider.Filter(rectangles);


            result.RainDropAreas = rectangles;
            result.OriginalImageWithRainDropAreas = new DrawRectangles(filteredRectangles).Apply(resizedImage);

            return result;
        }


    }
}
