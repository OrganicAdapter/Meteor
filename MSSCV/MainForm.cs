using AForge.Imaging.Filters;
using CloudDetection.ViewModels;
using CloudMovement.ViewModels;
using DSP;
using MSSCV.Helpers;
using MSSCV.RainDetector.Models;
using MSSCVLib.Datas;
using MSSCVLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MSSCV
{
    public partial class MainForm : Form
    {
        private List<Bitmap> VerticalImages { get; set; }
        private List<Bitmap> HorizontalImages { get; set; }


        private IImageProcessService CloudDetector { get; set; }
        private IImageProcessService CloudMovement { get; set; }


        private List<Subresult> Subresults { get; set; }
        private BindingSource SubresultsBinding { get; set; }
        private List<Result> Results { get; set; }
        private BindingSource ResultsBinding { get; set; }
        private bool IsRunning { get; set; }

        private int _childFormNumber;


        public MainForm()
        {
            CloudDetector = new CloudDetectionViewModel();
            CloudDetector.SubresultAvailableEvent += SubresultAvailable;
            CloudMovement = new CloudMovementViewModel();
            CloudMovement.SubresultAvailableEvent += SubresultAvailable;

            Subresults = new List<Subresult>();
            SubresultsBinding = new BindingSource();
            Results = new List<Result>();
            ResultsBinding = new BindingSource();

            IsRunning = false;

            InitializeComponent();

            SubresultsBinding.DataSource = Subresults;
            subresultGrid.DataSource = SubresultsBinding;

            ResultsBinding.DataSource = Results;
            resultGrid.DataSource = ResultsBinding;
        }


        private void ShowNewForm(object sender, EventArgs e)
        {
            var childForm = new Form
            {
                MdiParent = this, 
                Text = "Window " + _childFormNumber++
            };
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            //var openFileDialog = new OpenFileDialog
            //{
            //    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            //    Multiselect = true,
            //    Filter = "Image Files (*.jpg)|*.jpg"
            //};

            //if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    var images = new Dictionary<IDescriptedKey, Bitmap>();
            //    foreach (var filename in openFileDialog.FileNames)
            //    {
            //        images.Add(new DescriptedKey { Key = filename, Description = filename }, new Bitmap(filename));
            //    }

            //    new ImageForm(images) 
            //    { 
            //        MdiParent = this 
            //    }.Show();
            //}
            HorizontalImages = OpenFileService.OpenMultipleImages();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void SubresultAvailable(object sender, string result)
        {
            Invoke((MethodInvoker) delegate
            {
                Subresults.Add(new Subresult() { Sender = sender.ToString(), Value = result });
                SubresultsBinding.ResetBindings(false);
            });
        }

        private void OpenVerticalImages(object sender, EventArgs e)
        {
            VerticalImages = OpenFileService.OpenMultipleImages();
        }

        private async void Run(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                MessageBox.Show("Process already running...");
                return;
            }

            if (VerticalImages != null && VerticalImages.Count != 0)
            {
                IsRunning = true;

                //Results.Add(new Result() { Date = DateTime.Now.ToString(), Value = await CloudDetector.ProcessImage(VerticalImages) });
                //ResultsBinding.ResetBindings(false);
                Results.Add(new Result() { Date = DateTime.Now.ToString(), Value = await CloudMovement.ProcessImage(VerticalImages) });
                ResultsBinding.ResetBindings(false);

                IsRunning = false;
            }
            else
            {
                MessageBox.Show("No images opened...");
                return;
            }
        }

        private void OpenManualConfiguration(object sender, EventArgs e)
        {
            ManualCloudThresholdConfiguration window = new ManualCloudThresholdConfiguration();
            window.ShowDialog();
        }        
        
        private void automaticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (CloudDetector as CloudDetectionViewModel).AutoConfigureThresholds(VerticalImages[0]);
        }

        private void tollstripTextBox_TextChanged(object sender, EventArgs e)
        {
            int quarter = 20;
            int.TryParse(toolStripTextBox2.Text, out quarter);

            int direction = 0;
            int.TryParse(toolStripTextBox1.Text, out direction);

            (CloudMovement as CloudMovementViewModel).SaveValues(quarter, direction);
        }

    }
}