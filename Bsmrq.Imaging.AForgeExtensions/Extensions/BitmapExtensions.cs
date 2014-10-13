using AForge.Imaging;
using System.Threading.Tasks;

namespace System.Drawing
{
    /// <summary>
    /// Extensions for the Bitmap object mainly using AForge filters and features.
    /// </summary>
    public static class BitmapExtensions
    {
        /// <summary>
        /// Resizes the image to fit in a rectangle given in the parameters.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="maxWidth">Maximum width.</param>
        /// <param name="maxHeight">Maximum height.</param>
        /// <returns>Resized image.</returns>
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

        /// <summary>
        /// Finds the blobs on the image and returns with its rectangles asynchronously.
        /// </summary>
        /// <param name="image">Source image.</param>
        /// <param name="maxWidth">Maximum blob width.</param>
        /// <param name="minWidth">Minimum blob width.</param>
        /// <param name="maxHeight">Maximum blob height.</param>
        /// <param name="minHeight">Minimum blob height.</param>
        /// <returns>Rectangles around the blobs.</returns>
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

            await Task.Run(() => blobCounter.ProcessImage(image));

            var rectangles = blobCounter.GetObjectsRectangles();

            return rectangles;
        }
    }
}
