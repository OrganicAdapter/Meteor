using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace DarkSkyProject.Converters
{
    class BitmapToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var img = (Bitmap)value;

            if (img == null)
                return new BitmapImage();

            var bmImg = new BitmapImage();

            using (var memStream2 = new MemoryStream())
            {
                img.Save(memStream2, ImageFormat.Jpeg);

                bmImg.BeginInit();
                bmImg.CacheOption = BitmapCacheOption.OnLoad;
                bmImg.UriSource = null;
                memStream2.Seek(0, SeekOrigin.Begin);
                bmImg.StreamSource = memStream2;
                bmImg.EndInit();
            }

            return bmImg;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
