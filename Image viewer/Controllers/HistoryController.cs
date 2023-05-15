using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_viewer.Controllers
{
    public class HistoryController
    {
        int currentIndex = -1;
        ComboBox combo;
        public HistoryController(ComboBox combo)
        {
            this.combo = combo;
        }
        public void Add(string newRecord)
        {
            currentIndex++;
            combo.Items.Add(newRecord);
        }
        public string MoveBack()
        {
            currentIndex--;
            if(currentIndex > -1) 
            {
                return combo.Items[currentIndex].ToString();
            }
            currentIndex++;
            return combo.Items[currentIndex].ToString();
        }

        public string MoveForward()
        {
            currentIndex++;
            if(currentIndex < combo.Items.Count && currentIndex >-1)
            {
                return combo.Items[currentIndex].ToString();
            }
            else
            {
                currentIndex--;
                return combo.Items[currentIndex].ToString();
            }
        }

        public void Clear()
        {
            combo.Items.Clear();
            currentIndex = -1;
        }
    }
}
