using CloudDetection.ViewModels;
using CloudMovement.ViewModels;
using MSSCV.Helpers;
using MSSCVLib.Datas;
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
    public partial class CloudForm : Form
    {
        private CloudDetectionViewModel CloudDetector { get; set; }
        private CloudMovementViewModel CloudMovement { get; set; }


        private List<Subresult> Subresults { get; set; }
        private BindingSource SubresultsBinding { get; set; }
        private List<Result> Results { get; set; }
        private BindingSource ResultsBinding { get; set; }


        public CloudForm()
        {
            CloudDetector = new CloudDetectionViewModel();
            CloudDetector.SubresultAvailableEvent += SubresultAvailable;
            CloudMovement = new CloudMovementViewModel();
            CloudMovement.SubresultAvailableEvent += SubresultAvailable;

            Subresults = new List<Subresult>();
            SubresultsBinding = new BindingSource();
            Results = new List<Result>();
            ResultsBinding = new BindingSource();

            InitializeComponent();

            SubresultsBinding.DataSource = Subresults;
            subresultGrid.DataSource = SubresultsBinding;

            ResultsBinding.DataSource = Results;
            resultGrid.DataSource = ResultsBinding;
        }


        public async void DetectClouds(List<Bitmap> images)
        {
            this.Text = "Detect Clouds";

            Results.Add(new Result() { Date = DateTime.Now.ToString(), Value = await CloudDetector.ProcessImage(images) });
            ResultsBinding.ResetBindings(false);
        }

        public async void DetectCloudMovement(List<Bitmap> images)
        {
            this.Text = "Detect Cloud Movement";

            Results.Add(new Result() { Date = DateTime.Now.ToString(), Value = await CloudMovement.ProcessImage(images) });
            ResultsBinding.ResetBindings(false);
        }


        private void SubresultAvailable(object sender, string result)
        {
            Subresults.Add(new Subresult() { Sender = sender.ToString(), Value = result });
            SubresultsBinding.ResetBindings(false);
        }
    }
}
