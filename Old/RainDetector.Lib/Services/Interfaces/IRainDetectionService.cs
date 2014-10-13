using System.Drawing;
using System.Threading.Tasks;
using RainDetector.Lib.Models;

namespace RainDetector.Lib.Services
{
    public interface IRainDetectionService
    {
        Task<RainDetectionResult> DetectRaindrops(Bitmap image);
    }
}