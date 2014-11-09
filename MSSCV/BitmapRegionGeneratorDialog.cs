using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSCV
{
    public partial class BitmapRegionGeneratorDialog : Form
    {
        private Point _currentRegionStartLocation;
        private Pen _regionBrush = new Pen(Color.Green);


        public Bitmap Image { get; set; }

        public List<Rectangle> CurrentRegions { get; set; }

        public List<Rectangle> AdjustedRegions { get; set; }


        public BitmapRegionGeneratorDialog(Bitmap image)
        {
            InitializeComponent();

            CurrentRegions = new List<Rectangle>();
            AdjustedRegions = new List<Rectangle>();
            Image = image;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            imagePictureBox.Image = Image;
        }

        private void imagePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var currentRegion = CurrentRegions[CurrentRegions.Count - 1];
                var currentLocation = e.Location;

                currentRegion.Location = new Point(
                    Math.Min(_currentRegionStartLocation.X, currentLocation.X),
                    Math.Min(_currentRegionStartLocation.Y, currentLocation.Y));
                currentRegion.Size = new Size(
                    Math.Abs(_currentRegionStartLocation.X - currentLocation.X),
                    Math.Abs(_currentRegionStartLocation.Y - currentLocation.Y));

                CurrentRegions[CurrentRegions.Count - 1] = currentRegion;

                imagePictureBox.Invalidate();
            }
        }

        private void imagePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _currentRegionStartLocation = e.Location;

                CurrentRegions.Add(new Rectangle());
                AdjustedRegions.Add(new Rectangle());
            }
        }

        private void imagePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (imagePictureBox.Image != null)
            {
                foreach (var rectangle in CurrentRegions)
                {
                    e.Graphics.DrawRectangle(_regionBrush, rectangle);
                }
            }
        }

        private void imagePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                regionsListBox.Items.Clear();

                for (int i = 0; i < CurrentRegions.Count; i++)
                {
                    var widthRate = (float)Image.Width / (float)640;
                    var heightRate = (float)Image.Height / (float)480;

                    var currentAdjustedRegion = AdjustedRegions[i];

                    currentAdjustedRegion.Location = new Point(
                        (int)(Math.Round(CurrentRegions[i].Location.X * widthRate)),
                        (int)(Math.Round(CurrentRegions[i].Location.Y * heightRate)));

                    currentAdjustedRegion.Size = new Size(
                        (int)(Math.Round(CurrentRegions[i].Size.Width * widthRate)),
                        (int)(Math.Round(CurrentRegions[i].Size.Height * heightRate)));

                    AdjustedRegions[i] = currentAdjustedRegion;

                    regionsListBox.Items.Add(currentAdjustedRegion.ToString());
                }
            }
        }
    }
}
