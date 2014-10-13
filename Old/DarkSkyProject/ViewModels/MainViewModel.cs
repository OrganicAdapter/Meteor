using System.Drawing;
using System.Windows.Media.Imaging;
using DarkSkyProject.ViewModels.Base;
using DarkSkyProject.Common.Models;

namespace DarkSkyProject.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _openedImageFileName;
        private string _selectedKey;
        private Bitmap _selectedImage;

        public Bitmap SelectedImage
        {
            get { return _selectedImage; }
            set { SetProperty(ref _selectedImage, value); }
        }

        public string SelectedKey
        {
            get { return _selectedKey; }
            set { SetProperty(ref _selectedKey, value); SelectedImage = Common.GetImage(value); }
        }

        public string OpenedImageFileName
        {
            get { return _openedImageFileName; }
            set { SetProperty(ref _openedImageFileName, value); }
        }

        public ICommonImageSource Common
        {
            get { return CommonImageSource.Instance; }
        }


        public MainViewModel()
        {
            Common.PropertyChanged += Common_PropertyChanged;
        }


        void Common_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
