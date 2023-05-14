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
                if (col == 1)
                {
                    throw (new Exception());
                }
                else return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }
    }
}
