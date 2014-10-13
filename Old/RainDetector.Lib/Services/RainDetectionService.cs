using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math;
using DarkSkyProject.Common.Models;
using RainDetector.Lib.Imaging;
using RainDetector.Lib.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace RainDetector.Lib.Services
{
    public class RainDetectionService : IRainDetectionService
    {
        private readonly IImageProcessingProvider _imageProcessingProvider;
        private Bitmap _originalImage;
        private Bitmap _scaledImage;
        private Bitmap _preProcessedImage;
        private Bitmap _maskedImage;
        private Bitmap _blobDetectedImage;
        private Bitmap _filteredBlobDetectedImage;
        private Bitmap _rainDetectedImage;
        private Bitmap _grayscaleImage;
        private Bitmap _originalHistogram;
        private Bitmap _avgHistogram;
        private Bitmap[] _croppedImages;
        private Histogram[] _histsOfCroppedImages;
        private Blob[] _detectedBlobs;
        private Histogram _originalHistogramObject;
        private Histogram _avgHistogramObject;
        private Rectangle[] _blobAreas;
        private Rectangle[] _filteredBlobArray;
        private Rectangle[] _rainDropAreas;
        private int _blobCount;
        private int _filteredBlobCount;
        private int _rainDropCount;
        private int[] _compressedOriginalHistValues;
        private int[] _compressedAvgBlobHistValues;


        private Bitmap _erodedImage;


        public RainDetectionService(IImageProcessingProvider imageProcessingProvider)
        {
            _imageProcessingProvider = imageProcessingProvider;
        }


        public async Task<RainDetectionResult> DetectRaindrops(Bitmap image)
        {
            _originalImage = image;

            if (_originalImage.Width > 800 || _originalImage.Height > 600)
            {
                _scaledImage = await ScaleImage(new Bitmap(_originalImage), 800, 600);
            }
            else
            {
                _scaledImage = new Bitmap(_originalImage);
            }

            _preProcessedImage = await _imageProcessingProvider.Process(image);

            await DetectBlobs();
            await ShowBlobs();
            await FilterBlobs();
            await CalculateOriginalHistogram();
            await CalculateAverageBlobOriginalHistogram();
            await CompareHistograms();

            await Asd();

            var result = new RainDetectionResult
            {
                BlobDetectedImage = _blobDetectedImage,
                RaindropCount = _rainDropCount,
                BlobCount = _blobCount,
                FilteredBlobDetectedImage = _filteredBlobDetectedImage,
                FilteredBlobCount = _filteredBlobCount,
                MaskedImage = _maskedImage,
                PreProcessedImage = _preProcessedImage,
                RaindropDetectedImage = _rainDetectedImage,
                OriginalHistogram = _originalHistogram,
                AverageHistogram = _avgHistogram
            };

            return result;
        }


        private async Task DetectBlobs()
        {
            _grayscaleImage = new GrayscaleBT709().Apply(_scaledImage);

            var blobCounter = new BlobCounter
            {
                MinHeight = _preProcessedImage.Width / 32,
                MinWidth = _preProcessedImage.Height / 32,
                MaxWidth = _preProcessedImage.Width / 4,
                MaxHeight = _preProcessedImage.Height / 4,
                FilterBlobs = false,

            };

            blobCounter.ProcessImage(_preProcessedImage);

            _maskedImage = new Bitmap(_grayscaleImage);

            _detectedBlobs = blobCounter.GetObjects(_grayscaleImage, false);
            _blobAreas = blobCounter.GetObjectsRectangles();
            _blobCount = blobCounter.ObjectsCount;
        }

        private async Task ShowBlobs()
        {
            _blobDetectedImage = new Bitmap(_grayscaleImage);

            var drawRectangles = new DrawRectangles(_blobAreas);
            drawRectangles.Apply(_blobDetectedImage);
        }

        private async Task FilterBlobs()
        {
            _filteredBlobArray = await FilterRectangles(_blobAreas);
            _filteredBlobCount = _filteredBlobArray.Length;

            _filteredBlobDetectedImage = new Bitmap(_grayscaleImage);

            var drawRectangles = new DrawRectangles(_filteredBlobArray);
            drawRectangles.Apply(_filteredBlobDetectedImage);
        }

        private async Task CalculateOriginalHistogram()
        {
            var imageStat = new ImageStatistics(_grayscaleImage);

            _originalHistogramObject = new Histogram(await Smooth(imageStat.Gray.Values));

            _originalHistogram = _originalHistogramObject.GetBitmap(90);
        }

        private async Task CalculateAverageBlobOriginalHistogram()
        {
            var grayscaleFilter = new GrayscaleBT709();

            _croppedImages = _filteredBlobArray.Select(p => new Crop(p).Apply(_grayscaleImage.Clone() as Bitmap)).ToArray();


            _histsOfCroppedImages = _croppedImages
                .Select(img => new ImageStatistics(img).Gray)
                .ToArray();

            var avgHist = new int[256];

            for (int i = 0; i < 256; i++)
            {
                avgHist[i] = Convert.ToInt32(_histsOfCroppedImages.Sum(val => val.Values[i]));
            }

            var smoothed = await Smooth(avgHist);

            _avgHistogramObject = new Histogram(smoothed);

            _avgHistogram = _avgHistogramObject.GetBitmap(90);
        }

        private async Task CompareHistograms()
        {
            _compressedOriginalHistValues = await CompressArray(_originalHistogramObject.Values, 10, 30);

            var compressedBlobHistValues = _histsOfCroppedImages
                .Select(p => CompressArray(p.Values, 10, 30))
                .ToList();
        }

        private async Task<Rectangle[]> FilterRectangles(Rectangle[] rectangles)
        {
            IEnumerable<Rectangle> newArray;

            var avgWidth = rectangles.Average(p => p.Width);
            var avgHeight = rectangles.Average(p => p.Height);

            var requiredMaxWidth = Convert.ToInt32((float)avgWidth * 3.2f) + 1; // Sok a nyújtott széles esőcsepp.
            var requiredMinWidth = Convert.ToInt32((float)avgWidth * 0.6f) - 1;
            var requiredMaxHeight = Convert.ToInt32((float)avgWidth * 2.7f) + 1;
            var requiredMinHeight = Convert.ToInt32((float)avgWidth * 0.6f) - 1;

            newArray = rectangles.Where(p => p.Width >= requiredMinWidth
                && p.Width <= requiredMaxWidth
                && p.Height >= requiredMinHeight
                && p.Height <= requiredMaxHeight);

            var higherRectangles = new List<Rectangle>();

            foreach (var rectangle in newArray)
            {
                var newWidth = Convert.ToInt32(rectangle.Width * 1.5);
                var newHeight = Convert.ToInt32(rectangle.Height * 1.5);
                var x = rectangle.X - (newWidth - rectangle.Width) / 2;
                var y = rectangle.Y - (newHeight - rectangle.Height) / 2;

                higherRectangles.Add(new Rectangle(x, y, newWidth, newHeight));
            }

            var mergedRectangles = new List<Rectangle>();

            for (int i = 0; i < higherRectangles.Count; i++)
            {
                var rectA = higherRectangles[i];
                var newRect = new Rectangle(rectA.X, rectA.Y, rectA.Width, rectA.Height);

                for (int j = i + 1; j < higherRectangles.Count; j++)
                {
                    var rectB = higherRectangles[j];

                    var intersect = Rectangle.Intersect(newRect, rectB);

                    float percentA = intersect.Width * intersect.Height / (float)(newRect.Width * newRect.Height);
                    float percentB = intersect.Width * intersect.Height / (float)(rectB.Width * rectB.Height);

                    if (percentA > 0.4f || percentB > 0.4f)
                    {
                        newRect = Rectangle.Union(newRect, rectB);
                        higherRectangles.Remove(higherRectangles[j]);
                        //j--;
                        j = i + 1;
                        continue;
                    }

                    //var distance = Math.Abs(newRect.Bottom - rectB.Top);
                    //var widthDifference = Math.Abs(newRect.Width - rectB.Width);

                    //if (distance < 4 && widthDifference < Convert.ToInt32(newRect.Width * 0.1f))
                    //{
                    //    rectA = Rectangle.Union(newRect, rectB);
                    //    higherRectangles.Remove(higherRectangles[j]);
                    //    j--;
                    //    continue;
                    //}

                }

                mergedRectangles.Add(newRect);
            }

            return mergedRectangles.ToArray();
        }

        private async Task<Bitmap> ScaleImage(Bitmap image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        private async Task<int[]> Smooth(int[] source, int range = 1)
        {
            var result = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                var newValue = 0;
                var start = i < range ? 0 : i - range;
                var finish = source.Length - range > i ? i + range : source.Length - 1;

                for (int j = start; j <= finish; j++)
                {
                    newValue += source[j];
                }

                newValue = Convert.ToInt32((float)newValue / (2 * range + 1));

                result[i] = newValue;
            }

            return result;
        }

        private async Task<int[]> CompressArray(int[] array, int streaksPerRegion, int stretch = 0)
        {
            var newArrayValues = new List<int>();

            float m = 1;

            if (stretch > 0)
            {
                var max = array.Max();
                m = (float)stretch / max;
            }

            for (int i = 0; i < array.Length; i += streaksPerRegion)
            {
                var sum = 0;

                for (int j = i; (j < (i + streaksPerRegion) - 1) && (j < array.Length); j++)
                {
                    sum += array[j];
                }

                newArrayValues.Add(Convert.ToInt32(((float)sum / streaksPerRegion) * m));
            }

            return newArrayValues.ToArray();
        }


        private async Task Asd()
        {
            var se = new short[21, 21];

            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    se[i, j] = 1;
                }
            }

            var erosion = new Erosion(se);
            var greyscale = new GrayscaleBT709();
            var otsu = new OtsuThreshold();

            var image = new Bitmap(_scaledImage);
            image = greyscale.Apply(image);
            image = erosion.Apply(image);
            image = otsu.Apply(image);


            var whiteImage = DspInvert.Apply(new Bitmap(image.Width, image.Height));


            var blobCounterToLight = new BlobCounter
            {
                MinHeight = 10,
                MinWidth = 200,
                FilterBlobs = false,
            };

            blobCounterToLight.ProcessImage(image);

            var detectedLightBlobs = blobCounterToLight.GetObjects(whiteImage, true);
            var biggestLightBlob = detectedLightBlobs.FirstOrDefault(x => x.Rectangle.Width * x.Rectangle.Height == detectedLightBlobs.Max(y => y.Rectangle.Width * y.Rectangle.Height));

            var lightMask = new ApplyMask(biggestLightBlob.Image);
            var lightRegion = lightMask.Apply(new Bitmap(_scaledImage));

            CommonImageSource.Instance.SetImage("LightRegion", lightRegion);

        }
    }

}
