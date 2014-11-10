using Accord.Imaging;
using AForge;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMovement.Models
{
    public class DirectionDetectorService
    {
        private int threshold = 20;
        private int windThreshold = 10;

        private float harristhreshold = 500;

        public async Task<string> DetectDirection(List<Bitmap> inputList)
        {
            var result = "";
            var degrees = new List<double>();

            await Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < inputList.Count - 1; i++)
                    {
                        try
                        {
                            var harris = new HarrisCornersDetector(0.04f, harristhreshold);
                            var firstImagePoints = harris.ProcessImage(inputList[i]).ToArray();
                            var secondImagePoints = harris.ProcessImage(inputList[i + 1]).ToArray();

                            var correlation = new CorrelationMatching(11, inputList[i], inputList[i + 1]);
                            var matches = correlation.Match(firstImagePoints, secondImagePoints);

                            var ransac = new RansacHomographyEstimator(0.0001, 0.1);
                            var homography = ransac.Estimate(matches);

                            if (Math.Abs(homography.OffsetX) >= windThreshold || Math.Abs(homography.OffsetY) >= windThreshold)
                            {
                                var directionDegrees = Math.Atan2(homography.OffsetY, homography.OffsetX) * (180 / Math.PI);
                                degrees.Add(directionDegrees);
                            }
                        }

                        catch (ArgumentException)
                        {
                            i = i - 1;
                            harristhreshold /= 2;
                        }

                        catch (IndexOutOfRangeException)
                        {
                            i = i - 1;
                            harristhreshold /= 2;
                        }
                    }

                    var array = new int[8];

                    if (degrees.Count == 0)
                    {
                        result = "No wind detected!";
                    }
                    else
                    {
                        foreach (var direction in degrees)
                        {
                            if (direction <= 180 && direction >= 180 - threshold)
                                //result = "NY";
                                array[0]++;
                            else if (direction <= 180 - threshold && direction >= 90 + threshold)
                                //result = "ÉNY";
                                array[1]++;
                            else if (direction <= 90 + threshold && direction >= 90 - threshold)
                                //result = "É";
                                array[2]++;
                            else if (direction <= 90 - threshold && direction >= threshold)
                                //result = "ÉK";
                                array[3]++;
                            else if (direction <= threshold && direction >= 0)
                                //result = "K";
                                array[4]++;
                            else if (direction <= -180 + threshold)
                                //result = "NY";
                                array[0]++;
                            else if (direction <= -180 + threshold && direction >= -90 - threshold)
                                //result = "DNY";
                                array[5]++;
                            else if (direction <= -90 + threshold && direction >= -90 - threshold)
                                //result = "D";
                                array[6]++;
                            else if (direction <= -threshold && direction >= -90 + threshold)
                                //result = "DK";
                                array[7]++;
                            else if (direction >= -threshold)
                                //result = "K";
                                array[4]++;
                        }

                        var max = 0;
                        var maxValue = 0;

                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] >= maxValue)
                            {
                                max = i;
                                maxValue = array[i];
                            }
                        }

                        if (max == 0)
                            result = "NY";
                        else if (max == 1)
                            result = "ÉNY";
                        else if (max == 2)
                            result = "É";
                        else if (max == 3)
                            result = "ÉK";
                        else if (max == 4)
                            result = "K";
                        else if (max == 5)
                            result = "DNY";
                        else if (max == 6)
                            result = "D";
                        else if (max == 7)
                            result = "DK";
                    }
                });


            return result;
        }
    }
}
