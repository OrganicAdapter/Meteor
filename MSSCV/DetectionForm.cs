using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bsmrq.Imaging.AForgeExtensions.Extensions;
using MSSCV.RainDetector.Models;
using MSSCV.RainDetector.Services;

namespace MSSCV
{
    public partial class DetectionForm : Form
    {
        private readonly IRaindropDetectionContext _context;


        public DetectionForm(IRaindropDetectionContext context)
        {
            InitializeComponent();

            _context = context;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            customPropertiesRichTextBox.Text = String.Join(Environment.NewLine, _context.CustomProperties.Select(
                property => String.Format("{0}: {1}", property.Key.Description, property.Value.ToString())));

            historyRichTextBox.Text = String.Join(Environment.NewLine, _context.History);

            imageSelectorComboBox.Items.AddRange(_context.Images.Keys.ToArray());
            imageSelectorComboBox.SelectedIndex = _context.Images.Count - 1;
        }

        private void imageSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selector = sender as ComboBox;
            var selectedImageKey = selector.SelectedItem as IDescriptedKey;
            var selectedImage = _context.Images[selectedImageKey];

            imagePictureBox.Image = selectedImage;
        }

    }
}
