using CloudDetection.ViewModels;
using MSSCVLib.Datas;
using MSSCVLib.Helpers;
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
    public partial class Form1 : Form
    {
        private CloudDetectionViewModel CloudDetector { get; set; }

        private List<Subresult> Subresults { get; set; }
        private BindingSource SubresultsBinding { get; set; }


        public Form1()
        {
            CloudDetector = new CloudDetectionViewModel();
            CloudDetector.SubresultAvailableEvent += SubresultAvailable;

            Subresults = new List<Subresult>();
            SubresultsBinding = new BindingSource();

            InitializeComponent();

            SubresultsBinding.DataSource = Subresults;
            subresultGrid.DataSource = SubresultsBinding;
        }


        private void DetectCloudMenuItem_Click(object sender, EventArgs e)
        {
            var image = OpenFileService.OpenSingleImage();
            var result = CloudDetector.ProcessImage(image);
        }

        private void SubresultAvailable(object sender, string result)
        {
            Subresults.Add(new Subresult() { Sender = sender.ToString(), Value = result });
            SubresultsBinding.ResetBindings(false);
        }
    }
}
