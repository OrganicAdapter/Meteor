using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Drawing
{
    public static class BitmapExtensions
    {
        public static Bitmap Resize(this Bitmap image, int maxWidth, int maxHeight)
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

        public static async Task<Rectangle[]> GetBlobRectangles(this Bitmap image, int maxWidth, int minWidth, int maxHeight, int minHeight)
        {
            var blobCounter = new BlobCounter
            {
                MinHeight = minHeight,
                MinWidth = minWidth,
                MaxWidth = maxWidth,
                MaxHeight = maxHeight,
                FilterBlobs = false,

            };

            blobCounter.ProcessImage(image);

            var rectangles = blobCounter.GetObjectsRectangles();

            return rectangles;
        }
    }
}
