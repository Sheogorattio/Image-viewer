using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_viewer.Controllers
{
    public class SortingController:IComparer
    {
        int col;
        public SortingController(int coloumn)
        {
            col = coloumn;
        }
        public int Compare(object x, object y)
        {
            string textX = ((ListViewItem)x).SubItems[col].Text;
            string textY = ((ListViewItem)y).SubItems[col].Text;

            return String.Compare(textX, textY);
        }
    }
}
