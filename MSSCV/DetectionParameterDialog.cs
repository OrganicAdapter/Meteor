using MSSCV.RainDetector.Models;
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
    public partial class DetectionParameterDialog : Form
    {
        public IDescriptedKey SelectedImageKey { get; set; }


        public DetectionParameterDialog(IDictionary<IDescriptedKey, Bitmap> images)
        {
            InitializeComponent();

            selectLatestImageComboBox.SelectedIndexChanged += selectLatestImageComboBox_SelectedIndexChanged;

            selectLatestImageComboBox.Items.AddRange(images.Keys.ToArray());
            selectLatestImageComboBox.SelectedIndex = images.Keys.Count - 1;
        }


        void selectLatestImageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selector = sender as ComboBox;
            SelectedImageKey = selector.SelectedItem as IDescriptedKey;
        }
    }
}
