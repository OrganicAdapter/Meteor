using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace RainDetector.Lib.Services
{
    public interface IImageSplitterService
    {
        Task<IList<Bitmap>> Split(Bitmap image);
    }
}
