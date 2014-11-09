using MSSCV.Helpers;
using MSSCV.RainDetector.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MSSCV
{
    public partial class MainForm : Form
    {
        private int _childFormNumber;


        public MainForm()
        {
            InitializeComponent();
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
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Multiselect = true,
                Filter = "Image Files (*.jpg)|*.jpg"
            };

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                var images = new Dictionary<IDescriptedKey, Bitmap>();
                foreach (var filename in openFileDialog.FileNames)
                {
                    images.Add(new DescriptedKey { Key = filename, Description = filename }, new Bitmap(filename));
                }

                new ImageForm(images) 
                { 
                    MdiParent = this 
                }.Show();
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new AboutBox().ShowDialog();
        }

        private void detectCloudsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var images = OpenFileService.OpenMultipleImages();

            if (images == null) return;

            var cloudForm = new CloudForm();
            cloudForm.Show();

            cloudForm.DetectClouds(images);
        }

        private void determineCloudmovementDirectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var images = OpenFileService.OpenMultipleImages();

            if (images == null) return;

            var cloudForm = new CloudForm();
            cloudForm.Show();

            cloudForm.DetectCloudMovement(images);
        }
    }
}