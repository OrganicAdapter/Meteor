using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using DarkSkyProject.Common.Annotations;
using System.Collections.ObjectModel;
using System;

namespace DarkSkyProject.Common.Models
{
    public class CommonImageSource : ICommonImageSource
    {
        static private ICommonImageSource _instance;

        static public ICommonImageSource Instance
        {
            get { return _instance ?? (_instance = new CommonImageSource()); }
        }


        private Bitmap _currentImage;
        private readonly ObservableCollection<string> _keys;
        private readonly Dictionary<string, Bitmap> _imagesDictionary;


        public event PropertyChangedEventHandler PropertyChanged;

        public Bitmap CurrentImage
        {
            get { return GetImage("Current"); }
            set { SetImage("Current", value); OnPropertyChanged(); }
        }

        public ObservableCollection<string> Keys
        {
            get { return _keys; }
        }


        private CommonImageSource()
        {
            _currentImage = null;
            _imagesDictionary = new Dictionary<string, Bitmap>();
            _keys = new ObservableCollection<string>();
        }


        public void SetImage(string key, Bitmap image)
        {
            if (_imagesDictionary.ContainsKey(key))
            {
                Keys.Remove(key);

                _imagesDictionary[key] = new Bitmap(image);
            }
            else
            {
                _imagesDictionary.Add(key, new Bitmap(image));
            }

            Keys.Add(key);
        }

        public Bitmap GetImage(string key)
        {
            key = key ?? String.Empty;

            return _imagesDictionary.ContainsKey(key) ? _imagesDictionary[key] : null;
        }

        public void RemoveImage(string key)
        {
            if (_imagesDictionary.ContainsKey(key))
            {
                Keys.Remove(key);

                _imagesDictionary.Remove(key);
            }
        }

        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
