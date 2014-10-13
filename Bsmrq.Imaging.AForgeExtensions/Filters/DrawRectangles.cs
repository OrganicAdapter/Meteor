using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace AForge.Imaging.Filters
{
    public class DrawRectangles
    {
        private readonly IEnumerable<Rectangle> _rectangles;
        private readonly object _lockObject = new object();
        private readonly RGB _rgb;
        private IntPtr _scan0;
        private BitmapData _bmData;
        private Bitmap _image;
        private int _nHeight, _nOffset;
        private int _nWidth;
        private int _stride;


        public DrawRectangles(IEnumerable<Rectangle> rectangles, RGB rgb)
        {
            _rectangles = rectangles;
            _rgb = rgb;
        }


        public Bitmap Apply(Bitmap source)
        {
            _image = source;

            Draw();

            return _image;
        }


        private void Draw()
        {
            _nWidth = _image.Width;
            _nHeight = _image.Height;
            _bmData = _image.LockBits(new Rectangle(0, 0, _nWidth, _nHeight), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            _stride = _bmData.Stride;
            _scan0 = _bmData.Scan0;

            lock (_lockObject)
            {
                unsafe
                {
                    var p = (byte*) (void*) _scan0;

                    _nOffset = _stride - _nWidth*3;

                    for (var y = 0; y < _nHeight; ++y)
                    {
                        for (var x = 0; x < _nWidth; ++x)
                        {
                            foreach (var rectangle in _rectangles)
                            {
                                var left = rectangle.Left;
                                var right = rectangle.Right;
                                var top = rectangle.Top;
                                var bottom = rectangle.Bottom;

                                if (((x == left || x == right) && y >= top && y <= bottom)
                                    || ((y == top || y == bottom) && x >= left && x <= right))

                                {
                                    p[0] = _rgb.Blue;
                                    p[1] = _rgb.Green;
                                    p[2] = _rgb.Red;
                                }
                            }
                            p += 3;
                        }
                        p += _nOffset;
                    }
                }

                _image.UnlockBits(_bmData);
            }
        }
    }
}