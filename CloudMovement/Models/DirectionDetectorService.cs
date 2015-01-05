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
    public delegate void SubprocessCompletedEventHandler(object sender, string result);

    public class DirectionDetectorService
    {
        public event SubprocessCompletedEventHandler SubprocessCompletedEven;

        private int directionthreshold = 0;
        private int threshold = 10;
        private int windThreshold = 10;
        private int errors = 0;

        private double directionDegrees = 0;

        private float harristhreshold = 500;
        private float k = 0.04f;

        private HarrisCornersDetector harris;
        private IntPoint[] firstImagePoints;
        private IntPoint[] secondImagePoints;
        private CorrelationMatching correlation;
        private IntPoint[][] matches;
        private RansacHomographyEstimator ransac;
        private MatrixH homography;
        private List<double> degrees;
        private string result = "";

        public void SetValues(int direction, int quarters)
        {
            directionthreshold = direction;
            threshold = quarters;
        }

        public async Task<string> DetectDirection(List<Bitmap> inputList)
        {
            result = "";
            degrees = new List<double>();

            await Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < inputList.Count - 1; i++)
                    {
                        try
                        {
                            if (errors != 5)
                            {
                                harris = new HarrisCornersDetector(k, harristhreshold);
                                firstImagePoints = harris.ProcessImage(inputList[i]).ToArray();
                                secondImagePoints = harris.ProcessImage(inputList[i + 1]).ToArray();

                                correlation = new CorrelationMatching(11, inputList[i], inputList[i + 1]);
                                matches = correlation.Match(firstImagePoints, secondImagePoints);

                                ransac = new RansacHomographyEstimator(0.0001, 0.1);
                                homography = ransac.Estimate(matches);

                                if (Math.Abs(homography.OffsetX) >= windThreshold || Math.Abs(homography.OffsetY) >= windThreshold)
                                {
                                    directionDegrees = Math.Atan2(homography.OffsetY, homography.OffsetX) * (180 / Math.PI);
                                    degrees.Add(directionDegrees);

                                    errors = 0;

                                    SubprocessCompletedEven(this, directionDegrees.ToString());
                                }
                            }
                            else
                            {
                                errors = 0;
                            }
                        }

                        catch (ArgumentException)
                        {
                            i = i - 1;
                            harristhreshold /= 2;
                            k -= 0.02f;

                            errors++;

                            SubprocessCompletedEven(this, "Needs more corners...");
                        }

                        catch (IndexOutOfRangeException)
                        {
                            i = i - 1;
                            harristhreshold /= 2;
                            k -= 0.02f;

                            errors++;

                            SubprocessCompletedEven(this, "Needs more corners...");
                        }

                        catch (OutOfMemoryException)
                        {
                            inputList[i] = new Bitmap(inputList[i], inputList[i].Width / 2, inputList[i].Height / 2);
                            inputList[i + 1] = new Bitmap(inputList[i + 1], inputList[i + 1].Width / 2, inputList[i + 1].Height / 2);

                            i = i - 1;
                            harristhreshold *= 2;
                            k += 0.02f;

                            errors++;

                            SubprocessCompletedEven(this, "Needs less corners...");
                        }
                    }

                    var array = new int[8];

                    if (degrees.Count == 0)
                    {
                        result = "Could not detect wind.";
                    }
                    else
                    {
                        foreach (var direction in degrees)
                        {
                            if (direction - directionthreshold <= 180 && direction - directionthreshold >= 180 - threshold)
                                //result = "K";
                                array[0]++;
                            else if (direction - directionthreshold <= 180 - threshold && direction - directionthreshold >= 90 + threshold)
                                //result = "DK";
                                array[1]++;
                            else if (direction - directionthreshold <= 90 + threshold && direction - directionthreshold >= 90 - threshold)
                                //result = "D";
                                array[2]++;
                            else if (direction - directionthreshold <= 90 - threshold && direction - directionthreshold >= threshold)
                                //result = "DNY";
                                array[3]++;
                            else if (direction - directionthreshold <= threshold && direction - directionthreshold >= 0)
                                //result = "NY";
                                array[4]++;
                            else if (direction - directionthreshold <= -180 + threshold)
                                //result = "K";
                                array[0]++;
                            else if (direction - directionthreshold >= -180 + threshold && direction - directionthreshold <= -90 - threshold)
                                //result = "ÉK";
                                array[5]++;
                            else if (direction - directionthreshold <= -90 + threshold && direction - directionthreshold >= -90 - threshold)
                                //result = "É";
                                array[6]++;
                            else if (direction - directionthreshold <= -threshold && direction - directionthreshold >= -90 + threshold)
                                //result = "ÉNY";
                                array[7]++;
                            else if (direction - directionthreshold >= -threshold)
                                //result = "NY";
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
                            result = "K";
                        else if (max == 1)
                            result = "DK";
                        else if (max == 2)
                            result = "D";
                        else if (max == 3)
                            result = "DNY";
                        else if (max == 4)
                            result = "NY";
                        else if (max == 5)
                            result = "ÉK";
                        else if (max == 6)
                            result = "É";
                        else if (max == 7)
                            result = "ÉNY";
                    }
                });


            return result;
        }
    }
}
