using MSSCV.RainDetector.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace MSSCV.RainDetector.Services
{
    public interface IRainDetectionTester
    {
        Task<IRaindropDetectionTestResult> Run(IRaindropDetectionContext context, IList<Rectangle> regions);
    }
}
