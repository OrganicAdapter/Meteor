using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainDetector.Lib.Services
{
    public class RectangleFilteringProvider : IRectangleFilteringProvider
    {
        public async Task<Rectangle[]> Filter(Rectangle[] rectangles)
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
                }

                mergedRectangles.Add(newRect);
            }

            return mergedRectangles.ToArray();
        }
    }
}
