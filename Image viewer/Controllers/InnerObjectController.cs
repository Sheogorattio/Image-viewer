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
        string curPath;
        public string CurPath { set { curPath = value; } get { return curPath; } }
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

        public void ChangePath(string path)
        {
            CurPath = path;
            PrevPath= path;
            InnerObjects.path = CurPath;
        }
        public void UpdateItemsList()
        {
           listView.Items.Clear();
           List<string> folders = InnerObjects.GetFolders();
           List<string> files = InnerObjects.GetFiles();
           foreach (string folder in folders)
           {
               DirectoryInfo info = new DirectoryInfo(CurPath + folder + "\\");
               var item = listView.Items.Add(folder);
               item.SubItems.Add(info.CreationTime.ToString());
                item.SubItems.Add("Folder");
                item.SubItems.Add(" ");
           }
           foreach(string file in files)
            {
                FileInfo info = new FileInfo(CurPath + file + "\\");
                var item = listView.Items.Add(file);
                item.SubItems.Add(info.CreationTime.ToString());
                item.SubItems.Add("File");
                item.SubItems.Add((info.Length/(Math.Pow(1024, 2))).ToString() + " MB");
            }
        }

        public void OpenInnerObject(string objectName)
        {
            PrevPath = CurPath;
            CurPath +=  objectName + "\\";
            if (OpenFolder(CurPath) == false)
            {
                OpenImage(CurPath);
            }
        }

        public bool OpenImage(string path)
        {
            string _path = path.Remove(path.Length - 1);
            if (File.Exists(_path))
            {
                try
                {
                    string ext = Path.GetExtension(_path);
                    if (ext == ".bmp" || ext == ".gif" || ext == ".jpeg" || ext == ".png" || ext == ".jpg")
                    {
                        using (var stream = new FileStream(_path, FileMode.Open, FileAccess.ReadWrite))
                        {
                            
                            pictureBox.Image = Image.FromStream(stream);
                            CurPath = PrevPath;

                            return true;
                        }
                    }
                    else CurPath = PrevPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Invalid picture format. Check image format.");
                    CurPath = PrevPath;

                }
            }
            return false;
        }

        public bool OpenFolder(string path)
        {
            if (Directory.Exists(path))
            {            
                InnerObjects.path = CurPath;
                UpdateItemsList();
                return true;
            }
            return false;
        }
    }
}
