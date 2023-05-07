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
        public Form1()
        {
            InitializeComponent();
            var drives = Directory.GetLogicalDrives();
            foreach (var drive in drives)
            {
                DriveComboBox.Items.Add(drive);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            InnerObjectsController controller = new InnerObjectsController(DriveComboBox.Text + PathTextBox.Text);
            controller.UpdateItemsList(listView1);
        }

    }
}
