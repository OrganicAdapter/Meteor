using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSCVLib.Helpers
{
    public class OpenFileService
    {
        /// <summary>
        /// Opens a single image file using OpenFileDialog.
        /// </summary>
        /// <returns>The selected image as bitmap.</returns>
        public static Bitmap OpenSingleImage()
        {
            var picker = new OpenFileDialog();
            picker.RestoreDirectory = true;

            if (picker.ShowDialog() == DialogResult.OK)
                return new Bitmap(picker.FileName);
            else
                return null;
        }
    }
}
