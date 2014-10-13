using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;

namespace DarkSkyProject.Common.Models
{
    public interface ICommonImageSource : INotifyPropertyChanged
    {
        Bitmap CurrentImage { get; set; }
        ObservableCollection<string> Keys { get; }

        void SetImage(string key, Bitmap image);
        Bitmap GetImage(string key);
        void RemoveImage(string key);
    }
}