using System.Threading.Tasks;
using MSSCV.RainDetector.Models;

namespace MSSCV.RainDetector.Services
{
    /// <summary>
    /// Service for detecting raindrop regions.
    /// </summary>
    public interface IRaindropDetector
    {
        /// <summary>
        /// Detects raindrop regions.
        /// </summary>
        /// <param name="context">Context containing the image to use as a source image.</param>
        /// <returns>Context filled with the result parameters.</returns>
        Task<IRaindropDetectionContext> Detect(IRaindropDetectionContext context);
    }
}
