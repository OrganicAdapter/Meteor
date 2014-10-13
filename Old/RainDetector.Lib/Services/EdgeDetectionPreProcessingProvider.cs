using System.Drawing;
using System.Threading.Tasks;
using AForge.Imaging.Filters;

namespace RainDetector.Lib.Services
{
    public class EdgeDetectionPreProcessingProvider : IImageProcessingProvider
    {
        private const int StructuringElementSize = 3;


        private IImageProcessingProvider _commonRainyImagePreProcessingProvider;


        public EdgeDetectionPreProcessingProvider(IImageProcessingProvider commonRainyImagePreProcessingProvider)
        {
            _commonRainyImagePreProcessingProvider = commonRainyImagePreProcessingProvider;
        }


        public async Task<Bitmap> Process(Bitmap image)
        {
            var canny = new CannyEdgeDetector(0, 1);
            var threshold = new Threshold(10);
            var dilatation = new Dilatation(GenerateStructuringElement());

            var imageToProcess = await _commonRainyImagePreProcessingProvider.Process(image);

            imageToProcess = canny.Apply(imageToProcess);
            imageToProcess = threshold.Apply(imageToProcess);
            //imageToProcess = dilatation.Apply(imageToProcess);

            return imageToProcess;
        }


        private short[,] GenerateStructuringElement()
        {
            var se = new short[StructuringElementSize, StructuringElementSize];

            for (var i = 0; i < StructuringElementSize; i++)
            {
                for (var j = 0; j < StructuringElementSize; j++)
                {
                    se[i, j] = 1;
                }
            }

            return se;
        }
    }
}
