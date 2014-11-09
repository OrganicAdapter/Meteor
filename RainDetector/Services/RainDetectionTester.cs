using AForge.Imaging;
using AForge.Imaging.Filters;
using MSSCV.RainDetector.Constants;
using MSSCV.RainDetector.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MSSCV.RainDetector.Services
{
    public class RainDetectionTester : IRainDetectionTester
    {
        private readonly IRaindropDetector _rainDetectionService;


        public RainDetectionTester(IRaindropDetector rainDetectionService)
        {
            _rainDetectionService = rainDetectionService;
        }
        
        
        public async Task<IRaindropDetectionTestResult> Run(IRaindropDetectionContext context, IList<Rectangle> regions)
        {
            var resultContext = await _rainDetectionService.Detect(context);

            var imageWithTestRegions = new Bitmap(context.Images[ImageKeys.SourceImages.Latest]);
            var drawRectanglesForTestRegions = new DrawRectangles(regions, new RGB(Color.Green));
            imageWithTestRegions = drawRectanglesForTestRegions.Apply(imageWithTestRegions);
            context.Images.Add(ImageKeys.TestImages.TestRegions, imageWithTestRegions);

            IRaindropDetectionTestResult result = null;
            await Task.Run(() =>
            {
                result = RunTest(context, regions);
            });

            return result;
        }


        private IRaindropDetectionTestResult RunTest(IRaindropDetectionContext context, IList<Rectangle> regions)
        {
            var matches = new List<Rectangle>();
            var falsePositives = new List<Rectangle>();

            var result = new RaindropDetectionTestResult
            {
                RaindropDetectionContext = context,
                TestRaindropRegions = regions
            };

            var rate = 640 / (float)context.Images[ImageKeys.SourceImages.Latest].Size.Width;
            var adjustedTestRegions = regions.Select(region => 
                new Rectangle(
                    new Point((int)Math.Round(region.X * rate), (int)Math.Round(region.Y * rate)),
                    new Size((int)Math.Round(region.Size.Width * rate), (int)Math.Round(region.Size.Height * rate)))).ToList();
            var testRegions = new List<Rectangle>(adjustedTestRegions);

            foreach (var foundRegion in context.RaindropRegions)
            {
                var matched = false;
                var i = 0;

                float highestIntersect = 0;
                var matchedTestRegion = testRegions[0];

                while (i < testRegions.Count)
                {
                    var testRegion = testRegions[i];
                    var intersect = Rectangle.Intersect(foundRegion, testRegion);

                    var percentA = intersect.Width * intersect.Height / 
                        (float)(testRegion.Width * testRegion.Height);
                    var percentB = intersect.Width * intersect.Height /
                        (float)(foundRegion.Width * foundRegion.Height);

                    var maxPercent = Math.Max(percentA, percentB);
                    if (maxPercent > 0.4f)
                    {
                        matched = true;

                        if (maxPercent > highestIntersect)
                        {
                            highestIntersect = maxPercent;
                            matchedTestRegion = testRegion;
                        }
                    }

                    i++;
                }

                if (matched)
                {
                    testRegions.Remove(matchedTestRegion);
                    matches.Add(foundRegion);
                }
                else
                {
                    falsePositives.Add(foundRegion);
                }
            }

            result.FalsePositive = falsePositives.Count;
            result.FalseNegative = testRegions.Count;
            result.TruePositive = matches.Count;

            var imageWithRectangles = new Bitmap(context.Images[ImageKeys.ResultImages.ImageWithRaindropRegions]);

            var drawRectanglesForTestRegions = new DrawRectangles(adjustedTestRegions, new RGB(Color.Green));
            var drawRectanglesForFalsePositives = new DrawRectangles(falsePositives, new RGB(Color.Red));

            imageWithRectangles = drawRectanglesForTestRegions.Apply(imageWithRectangles);
            imageWithRectangles = drawRectanglesForFalsePositives.Apply(imageWithRectangles);

            context.Images.Add(ImageKeys.TestImages.TestResults, imageWithRectangles);
            context.CustomProperties.Add(PropertyKeys.RainDetectionTest.Matches, result.TruePositive);
            context.CustomProperties.Add(PropertyKeys.RainDetectionTest.FalsePositives, result.FalsePositive);
            context.CustomProperties.Add(PropertyKeys.RainDetectionTest.FalseNegatives, result.FalseNegative);

            return result;
        }
    }
}
