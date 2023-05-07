using Image_viewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_viewer.Controllers
{
    internal class InnerObjectsController
    {
        InnerObjectsList InnerObjects;
        public InnerObjectsController(string path)
        {
            InnerObjects = new InnerObjectsList(path);
        }
        public void UpdateItemsList(ListView listView)
        {
           listView.Items.Clear();
           List<string> folders = InnerObjects.GetFolders();
           List<string> fildes = InnerObjects.GetFiles();
           foreach (string folder in folders)
           {
                listView.Items.Add(folder).ImageIndex = 1;
           }
            
        }
    }
}
