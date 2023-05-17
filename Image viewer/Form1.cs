using Image_viewer.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_viewer
{
    public partial class ImageViewer : Form
    {
        
        InnerObjectsController controller;
        CopyPasteController copyPasteController = new CopyPasteController();
        HistoryController historyController;
        FormatController formatController = new FormatController();
        public ImageViewer()
        {
            InitializeComponent();
            var drives = Directory.GetLogicalDrives();
            foreach (var drive in drives)
            {
                DriveComboBox.Items.Add(drive);
            }
            this.Text = "ImageViewer";
            historyController = new HistoryController(PathTextBox);
        }

        private void SearchButton_Click(object sender, EventArgs e)//click on the search button
        {
            if(PathCheckBox.Checked == true)
            {
                controller = new InnerObjectsController(PathTextBox.Text, listView1, pictureBox1);
                //PathTextBox.Items.Add(PathTextBox.Text);
                historyController.Add(PathTextBox.Text);
            }
            else { 
                controller = new InnerObjectsController(DriveComboBox.Text, listView1, pictureBox1);
                //PathTextBox.Items.Add(DriveComboBox.Text);
                historyController.Add(DriveComboBox.Text);
            }
            pictureBox1.Image = null;
            controller.UpdateItemsList();
            HistoryBack.Enabled = true;
            HistoryForward.Enabled = true;
            ClearHistory.Enabled = true;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)//double click on the selected file/folder
        {
            pictureBox1.Image = null;
            controller.OpenInnerObject(listView1.SelectedItems[0].Text);
            this.PathTextBox.Text = controller.CurPath;
            if (PathTextBox.Items[PathTextBox.Items.Count-1].ToString() != controller.CurPath || PathTextBox.Items.Count<1)
            {
                //PathTextBox.Items.Add(controller.CurPath);
                historyController.Add(PathTextBox.Text);
            }
            
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)//sorting
        {
            try
            {
                this.listView1.ListViewItemSorter = new SortingController(e.Column);
                listView1.Sort();
            }
            catch (Exception ex) { }
            this.listView1.Sorting = SortOrder.None;
            this.listView1.ListViewItemSorter = null;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyPasteController.Copy(PathTextBox.Text + listView1.SelectedItems[0].Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyPasteController.Paste(PathTextBox.Text);
            controller.UpdateItemsList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyPasteController.Delete(PathTextBox.Text + listView1.SelectedItems[0].Text);
            pictureBox1.Image = null;
            controller.UpdateItemsList();
        }

        private void HistoryBack_Click(object sender, EventArgs e)
        {
            
            controller = new InnerObjectsController(historyController.MoveBack(), listView1, pictureBox1);
            PathTextBox.Text = controller.CurPath;
            pictureBox1.Image = null;
            controller.UpdateItemsList();
        }

        private void HistoryForward_Click(object sender, EventArgs e)
        {
           
            controller = new InnerObjectsController(historyController.MoveForward(), listView1, pictureBox1);
            PathTextBox.Text = controller.CurPath;
            pictureBox1.Image = null;
            controller.UpdateItemsList();
        }

        private void ClearHistory_Click(object sender, EventArgs e)
        {
            historyController.Clear();
            controller = new InnerObjectsController(DriveComboBox.Items[0].ToString(), listView1, pictureBox1);
            PathTextBox.Text = controller.CurPath;
            pictureBox1.Image = null;
            historyController.Add(DriveComboBox.Items[0].ToString());
            controller.UpdateItemsList();
        }

        private void PathTextBox_SelectedValueChanged(object sender, EventArgs e)
        {
           controller.ChangePath(PathTextBox.Text);
           controller.UpdateItemsList();
           pictureBox1.Image= null;
        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formatController.Convert(PathTextBox.Text + listView1.SelectedItems[0].Text, ".png");
            controller.UpdateItemsList();
        }

        private void jpegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formatController.Convert(PathTextBox.Text + listView1.SelectedItems[0].Text, ".jpeg");
            controller.UpdateItemsList();
        }

        private void bmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formatController.Convert(PathTextBox.Text + listView1.SelectedItems[0].Text, ".bmp");
            controller.UpdateItemsList();
        }
    }
}
