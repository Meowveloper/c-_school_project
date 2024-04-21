using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZweFitnessTrackingAPP
{
    internal class ListBoxManager
    {
        //adding items in to listbox
        public void RerenderItems(ListBox listBox, params string[] items)
        {
            listBox.Items.Clear();
            foreach (string item in items)
            {
                listBox.Items.Add(item);
            }
            listBox.SelectedIndex = 0;
          
        }
    }
}
