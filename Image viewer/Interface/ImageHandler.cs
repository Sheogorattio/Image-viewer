using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_viewer.Interface
{
    public interface ImageHandler
    {
        bool OpenImage(string path);
    }
}
