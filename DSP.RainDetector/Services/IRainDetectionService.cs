using System.Threading.Tasks;
using DSP.RainDetector.Models;

namespace DSP.RainDetector.Services
{
    /// <summary>
    /// Service for detecting raindrop areas.
    /// </summary>
    public interface IRainDetectionService
    {
        /// <summary>
        /// Detects raindrop areas.
        /// </summary>
        /// <param name="context">Context containing the image to use as a source image.</param>
        /// <returns>Context filled with the result parameters.</returns>
        Task<IRainDetectionContext> Detect(IRainDetectionContext context);
    }
}
