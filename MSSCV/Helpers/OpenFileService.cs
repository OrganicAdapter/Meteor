using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSCV.Helpers
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

        public static List<Bitmap> OpenMultipleImages()
        {
            var picker = new OpenFileDialog();
            picker.RestoreDirectory = true;
            picker.Multiselect = true;

            if (picker.ShowDialog() == DialogResult.OK)
            {
                var images = new List<Bitmap>();

                foreach (var item in picker.FileNames)
                    images.Add(new Bitmap(item));

                return images;
            }
            else
                return null;
        }
    }
}