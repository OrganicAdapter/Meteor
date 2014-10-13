using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DSP
{
    public partial class DSPMainForm : Form
    {
        private int _childFormNumber;


        public DSPMainForm()
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
                Filter = "Image Files (*.jpg)|*.jpg"
            };

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;

                new ImageForm(new Bitmap(fileName), new Dictionary<string, string>(), new[] { "Opened" }.ToList()) { MdiParent = this }.Show();
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
            new DSPAboutBox().ShowDialog();
        }
    }
}