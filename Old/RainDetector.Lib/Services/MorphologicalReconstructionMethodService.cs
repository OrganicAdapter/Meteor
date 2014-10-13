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
    public class MorphologicalReconstructionMethodService : IRainDetectionMethodService
    {
        private readonly ICommonImageSource _commonImageSource;
        private readonly IImageProcessingProvider _commonPreProcessingProvider;
        private readonly IRectangleFilteringProvider _rectangleFilterProvider;
        private readonly IImageSplitterService _morphologicalReconstructionPreProcessingProvider;


        public MorphologicalReconstructionMethodService(ICommonImageSource commonImageSource, IImageProcessingProvider commonPreProcessingProvider,
            IRectangleFilteringProvider rectangleMergingProvider, IImageSplitterService morphologicalReconstructionPreProcessingProvider)
        {
            _commonImageSource = commonImageSource;
            _commonPreProcessingProvider = commonPreProcessingProvider;
            _rectangleFilterProvider = rectangleMergingProvider;
            _morphologicalReconstructionPreProcessingProvider = morphologicalReconstructionPreProcessingProvider;
        }


        public async Task<IRainDetectionMethodResult> Process(Bitmap image)
        {
            var result = new RainDetectionMethodResult();

            var resizedImage = image.Resize(640, 480);
            var preProcessedImage = await _commonPreProcessingProvider.Process(resizedImage);

            var morphResultImages = await _morphologicalReconstructionPreProcessingProvider.Split(preProcessedImage);
            var morphPreProcessedImage = morphResultImages.First();

            var rectangles = await morphPreProcessedImage.GetBlobRectangles(image.Width / 4, image.Height / 32, image.Height / 4, image.Width / 32);

            var filteredRectangles = await _rectangleFilterProvider.Filter(rectangles);


            result.RainDropAreas = rectangles;
            result.OriginalImageWithRainDropAreas = new DrawRectangles(filteredRectangles).Apply(resizedImage);

            return result;
        }
    }
}
