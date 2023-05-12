using Image_viewer.Interface;
using Image_viewer.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_viewer.Controllers
{
    public class InnerObjectsController: ImageHandler, FolderHandler
    {
        public string CurPath { set; get; }
        public string PrevPath { get; set; }
        InnerObjectsList InnerObjects;
        ListView listView;
        PictureBox pictureBox;
        public InnerObjectsController(string path, ListView listView, PictureBox pictureBox)
        {
            InnerObjects = new InnerObjectsList(path);
            CurPath = path;
            PrevPath = path;
            this.listView = listView;
            this.pictureBox = pictureBox;
        }
        public void UpdateItemsList()
        {
           listView.Items.Clear();
           List<string> folders = InnerObjects.GetFolders();
           List<string> fildes = InnerObjects.GetFiles();
           foreach (string folder in folders)
           {
                listView.Items.Add(folder).ImageIndex = 1;
           }
        }

        public void OpenInnerObject(string path)
        {
            if (OpenFolder(path) == false)
            {
                OpenImage(path);
            }
        }

        public bool OpenImage(string path)
        {
            if (File.Exists(path))
            {
                using (var img = Image.FromFile(path))
                {
                    pictureBox.Image = img;
                }
                return true;
            }
            return false;
        }

        public bool OpenFolder(string path)
        {
            if (Directory.Exists(path))
            {
                PrevPath = CurPath;
                CurPath = path;
                InnerObjects.path = CurPath;
                UpdateItemsList();
                return true;
            }
            return false;
        }
    }
}
