using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSCVLib.Interfaces
{
    public interface ISubProcessService
    {
        /// <summary>
        /// Process the input image in place.
        /// </summary>
        /// <param name="input"> Input image. </param>
        Task Execute(Bitmap input);
    }
}
