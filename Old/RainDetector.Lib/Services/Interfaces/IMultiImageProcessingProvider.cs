using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RainDetector.Lib.Services
{
    public interface IMultiImageProcessingProvider
    {
        Task<Bitmap> Process(Bitmap[] images);
    }


    public static class MultiImageProcessingProviderExtensions
    {
        public static Task<Bitmap> Process(this IMultiImageProcessingProvider imageProcessingProvider, Bitmap firstImage, Bitmap secondImage)
        {
            return imageProcessingProvider.Process(new Bitmap[] { firstImage, secondImage });
        }

        public static Task<Bitmap> Process(this IMultiImageProcessingProvider imageProcessingProvider, Bitmap firstImage, Bitmap secondImage, Bitmap thirdImage)
        {
            return imageProcessingProvider.Process(new Bitmap[] { firstImage, secondImage, thirdImage });
        }
    }
}