using System.Drawing;
using System.Threading.Tasks;

namespace RainDetector.Lib.Services
{
    public interface IImageProcessingProvider
    {
        Task<Bitmap> Process(Bitmap image);
    }
}