using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSCV.RainDetector.Models
{
    public interface IRaindropDetectionTestResult
    {
        IRaindropDetectionContext RaindropDetectionContext { get; }

        int FalsePositive { get; }

        int FalseNegative { get; }

        int TruePositive { get; }

        IList<Rectangle> TestRaindropRegions { get; }
    }


    public class RaindropDetectionTestResult : IRaindropDetectionTestResult
    {
        public IRaindropDetectionContext RaindropDetectionContext { get; set; }

        public int FalsePositive { get; set; }

        public int FalseNegative { get; set; }

        public int TruePositive { get; set; }

        public IList<Rectangle> TestRaindropRegions { get; set; }
    }
}
