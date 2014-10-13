using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AForge.Imaging;
using AForge.Imaging.Filters;
using RainDetector.Lib.Imaging;
using AForge;

namespace RainDetector.Lib.Services
{
    public class MorphologicalReconstructionPreProcessingProvider : IImageSplitterService
    {
        private const int StructuringElementSize = 5;

        private readonly short[,] _erosionStructuringElement;


        public MorphologicalReconstructionPreProcessingProvider()
        {
            _erosionStructuringElement = GenerateStructuringElement();
        }


        public async Task<IList<Bitmap>> Split(Bitmap image)
        {
            var imageList = new List<Bitmap>();

            var erosionFilter = new Erosion(_erosionStructuringElement);
            var greyscaleFilter = new GrayscaleBT709();
            //var thresholdFilter = new OtsuThreshold();
            var thresholdFilter = new Threshold(10);
            var invertFilter = new Invert();

            var clonedImage = new Bitmap(image);
            var greyscaleImage = greyscaleFilter.Apply(clonedImage);
            var erodedImage = erosionFilter.Apply(greyscaleImage);


            var morphFilter = new Morph(erodedImage);
            var morphedImage = morphFilter.Apply(greyscaleImage);

            var erodedImage2 = erosionFilter.Apply(invertFilter.Apply(morphedImage));
            var morphFilter2 = new Morph(erodedImage2);
            var morphedImage2 = morphFilter.Apply(invertFilter.Apply(morphedImage));

            var histeqImage = invertFilter.Apply(new ContrastStretch().Apply(morphedImage2));

            var binarizedImage = thresholdFilter.Apply(histeqImage);

            //var thrImg1 = new ColorFiltering(new IntRange(121, 180), new IntRange(121, 180), new IntRange(121, 180)).Apply(convertedHisteqImage);
            //var thrImg2 = new ColorFiltering(new IntRange(181, 200), new IntRange(181, 200), new IntRange(181, 200)).Apply(convertedHisteqImage);
            //var thrImg3 = new ColorFiltering(new IntRange(201, 220), new IntRange(201, 220), new IntRange(201, 220)).Apply(convertedHisteqImage);
            //var thrImg4 = new ColorFiltering(new IntRange(221, 240), new IntRange(221, 240), new IntRange(221, 240)).Apply(convertedHisteqImage);
            //var thrImg5 = new ColorFiltering(new IntRange(241, 250), new IntRange(241, 250), new IntRange(241, 250)).Apply(convertedHisteqImage);



            imageList.Add(binarizedImage);
            imageList.Add(erodedImage);
            imageList.Add(greyscaleImage);
            imageList.Add(morphedImage);
            imageList.Add(erodedImage2);
            imageList.Add(morphedImage2);

            return imageList;

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

        private Bitmap GetLargestBlobImage(Bitmap image)
        {
            var blobCounterToLight = new BlobCounter
            {
                MinHeight = 10,
                MinWidth = 200,
                FilterBlobs = false,
            };

            blobCounterToLight.ProcessImage(image);

            var blobs = blobCounterToLight.GetObjects(image, true);
            var largestBlob = blobs.FirstOrDefault(x => x.Rectangle.Width * x.Rectangle.Height == blobs.Max(y => y.Rectangle.Width * y.Rectangle.Height));

            return largestBlob.Image.ToManagedImage();
        }
    }
}