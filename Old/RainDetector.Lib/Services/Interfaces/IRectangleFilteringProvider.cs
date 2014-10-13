using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainDetector.Lib.Services
{
    public interface IRectangleFilteringProvider
    {
        Task<Rectangle[]> Filter(Rectangle[] rectangles);
    }
}
