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
    public partial class Form1 : Form
    {
        InnerObjectsController controller;
        public Form1()
        {
            InitializeComponent();
            var drives = Directory.GetLogicalDrives();
            foreach (var drive in drives)
            {
                DriveComboBox.Items.Add(drive);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)//click on the search button
        {
            if(PathCheckBox.Checked == true)
            {
                controller = new InnerObjectsController(PathTextBox.Text, listView1, pictureBox1);
            }
            else { 
            controller = new InnerObjectsController(DriveComboBox.Text, listView1, pictureBox1);
            }
            controller.UpdateItemsList();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)//double click on the selected file/folder
        {
            controller.OpenInnerObject(listView1.SelectedItems[0].Text);
            this.PathTextBox.Text = controller.CurPath;
        }

    }
}
