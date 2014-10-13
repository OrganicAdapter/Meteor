using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AForge.Imaging;
using AForge.Imaging.Filters;
using DSP.RainDetector.Models;

namespace DSP.RainDetector.Services
{
    /// <summary>
    /// Default implementation. For further information see IRainDetectionService.cs
    /// </summary>
    public class DefaultRainDetectionService : IRainDetectionService
    {
        /// <summary>
        /// Size of the structuring element in case of using dilatation on the image.
        /// </summary>
        private const int DilatationStructuringElementSize = 3;


        public async Task<IRainDetectionContext> Detect(IRainDetectionContext context)
        {
            // I. Preprocessing image.
            var preprocessedImage = await PreProcess(new Bitmap(context.OriginalImage), context.History);

            context.PreprocessedImage = preprocessedImage;

            // II. Default AForge blob detection and getting rectangles.
            var rectangles = await preprocessedImage.GetBlobRectangles(
                preprocessedImage.Width/4,
                preprocessedImage.Height/32,
                preprocessedImage.Height/4,
                preprocessedImage.Width/32);
            context.History.Add("Blob detection");

            // III. Filtering rectangles.
            var filteredRectangles = await FilterRectangles(rectangles);
            context.History.Add("Blob filtering");

            // IV. Counting the raindrops and drawing its rectangles on the original (resized) image.
            await Task.Run(() =>
            {
                context.FinalImage = new DrawRectangles(filteredRectangles, new RGB(Color.Yellow)).Apply(new Bitmap(context.OriginalImage.Resize(640, 480)));
                context.History.Add("Drawing blobs");
                context.RaindropCount = filteredRectangles.Count();
            });

            return context;
        }


        /// <summary>
        /// Preprocesses the image.
        /// </summary>
        /// <param name="bitmap">Image to preprocess.</param>
        /// <param name="history">History to append after the filters.</param>
        /// <returns>Preprocessed image.</returns>
        private static async Task<Bitmap> PreProcess(Bitmap bitmap, IList<string> history)
        {
            var median = new Median();
            var grayscale = Grayscale.CommonAlgorithms.BT709;
            var adaptiveSmoothFilter = new AdaptiveSmoothing();
            var canny = new CannyEdgeDetector(0, 1);
            var threshold = new Threshold(10);


            await Task.Run(() => bitmap = bitmap.Resize(640, 480));

            await Task.Run(() =>
            {
                bitmap = median.Apply(bitmap);
                history.Add("Median");
                bitmap = grayscale.Apply(bitmap);
                history.Add("BT709 grayscale");
                bitmap = adaptiveSmoothFilter.Apply(bitmap);
                history.Add("Adaptive smooth");
                bitmap = canny.Apply(bitmap);
                history.Add("Canny");
                bitmap = threshold.Apply(bitmap);
                history.Add("Threshold(10)");
            });

            return bitmap;
        }

        /// <summary>
        /// Filters the given rectangles.
        /// </summary>
        /// <param name="rectangles">Rectangles to filter.</param>
        /// <returns>Filtered rectangles.</returns>
        private static async Task<IEnumerable<Rectangle>> FilterRectangles(IEnumerable<Rectangle> rectangles)
        {
            var relevantRectangles = Enumerable.Empty<Rectangle>();

            var averageWidth = rectangles.Average(p => p.Width);

            // Limiting the size of the rectangles.
            var requiredMaxWidth = Convert.ToInt32((float)averageWidth * 3.2f) + 1;
            var requiredMinWidth = Convert.ToInt32((float)averageWidth * 0.6f) - 1;
            var requiredMaxHeight = Convert.ToInt32((float)averageWidth * 2.7f) + 1;
            var requiredMinHeight = Convert.ToInt32((float)averageWidth * 0.6f) - 1;

            await Task.Run(() =>
            {
                relevantRectangles = rectangles.Where(p => p.Width >= requiredMinWidth
                                                 && p.Width <= requiredMaxWidth
                                                 && p.Height >= requiredMinHeight
                                                 && p.Height <= requiredMaxHeight);
            });

            // Resizing rectangles to generate higher overlaps.
            var higherRectangles = new ConcurrentBag<Rectangle>();

            var addToHigherRectanglesTasks = relevantRectangles.Select(rectangle => Task.Run(() =>
            {
                var newWidth = Convert.ToInt32(rectangle.Width*1.5);
                var newHeight = Convert.ToInt32(rectangle.Height*1.5);
                var x = rectangle.X - (newWidth - rectangle.Width)/2;
                var y = rectangle.Y - (newHeight - rectangle.Height)/2;

                higherRectangles.Add(new Rectangle(x, y, newWidth, newHeight));
            }));

            await Task.WhenAll(addToHigherRectanglesTasks);

            var mergedRectangles = new List<Rectangle>();
            var removedRectangles = new List<Rectangle>();

            // Searching for big overlaps and merging the rectangles.
            await Task.Run(() =>
            {
                for (var i = 0; i < higherRectangles.Count; i++)
                {
                    var higherRectangle = higherRectangles.ElementAt(i);

                    if (removedRectangles.Contains(higherRectangle)) continue;

                    var newRectangle = new Rectangle(
                        higherRectangle.X,
                        higherRectangle.Y,
                        higherRectangle.Width,
                        higherRectangle.Height);

                    for (var j = i + 1; j < higherRectangles.Count; j++)
                    {
                        var anotherHigherRectangle = higherRectangles.ElementAt(j);

                        if (removedRectangles.Contains(anotherHigherRectangle)) continue;

                        var intersect = Rectangle.Intersect(newRectangle, anotherHigherRectangle);

                        var percentA = intersect.Width*intersect.Height/(float) (newRectangle.Width*newRectangle.Height);
                        var percentB = intersect.Width*intersect.Height/
                                       (float) (anotherHigherRectangle.Width*anotherHigherRectangle.Height);

                        if (percentA > 0.4f || percentB > 0.4f)
                        {
                            newRectangle = Rectangle.Union(newRectangle, anotherHigherRectangle);
                            removedRectangles.Add(anotherHigherRectangle);
                        }
                    }

                    mergedRectangles.Add(newRectangle);
                }
            });

            return mergedRectangles.ToArray();
        }

        /// <summary>
        /// Generates structuring element for AForge filters (ie. Erosion, Dilatation).
        /// </summary>
        /// <param name="structuringElement">Size of the structuring element.</param>
        /// <returns>Array for the AForge filters.</returns>
        private static short[,] GenerateStructuringElement(int structuringElement)
        {
            var se = new short[structuringElement, structuringElement];

            for (var i = 0; i < structuringElement; i++)
            {
                for (var j = 0; j < structuringElement; j++)
                {
                    se[i, j] = 1;
                }
            }

            return se;
        }
    }
}