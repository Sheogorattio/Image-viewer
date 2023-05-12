using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_viewer.Model
{
    internal class InnerObjectsList
    {
        List<string> folders = new List<string>();
        internal string path { get; set; }
        public List<string> Folders { set { folders.Add(value.ToString()); } }
        List<string> files = new List<string>();
        public List<string> Files { set { files.Add(value.ToString()); } }



        public InnerObjectsList (string path)
        {
            this.path = path;
        }
        void Updatelist()
        {
            folders.Clear();
            files.Clear();
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] dir = root.GetDirectories();
            FileInfo[] fls = root.GetFiles();
            foreach (FileInfo file in fls)
            {
                files.Add(file.Name);
            }
            foreach (DirectoryInfo drct in dir)
            {
                folders.Add(drct.Name);
            }
        }
        public List<string> GetObjectsList()
        {
            Updatelist();
            List<string> res = new List<string>();
            foreach(var obj in folders)
            {
                res.Add(obj.ToString());
            }
            foreach(var obj in files)
            {
                res.Add(obj.ToString());
            }
            return res;
        }
        public List<string> GetFolders()
        {
            Updatelist();
            return folders.ToList();
        }
        public List<string> GetFiles()
        {
            Updatelist();
            return files.ToList(); 
        }
    }
}
