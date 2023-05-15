using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_viewer.Controllers
{
    public class CopyPasteController
    {
        byte[] OriginalData;
        string OriginalFileName;
        public void Copy(string pathToFile)
        {
            if (File.Exists(pathToFile))
            {
                OriginalData = File.ReadAllBytes(pathToFile);
                OriginalFileName = Path.GetFileName(pathToFile);
            }
            else { MessageBox.Show("File does not exist."); }
        }

        public void Paste(string destinationPath) 
        { 
            File.WriteAllBytes(destinationPath+"_"+OriginalFileName, OriginalData);
            Copy(destinationPath + "_" + OriginalFileName);
        }

        public void Delete(string path)
        {
            File.Delete(path);
        }
    }
}
