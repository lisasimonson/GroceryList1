using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace GroceryList1
{
    public class ListItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Department { get; set; }

        public CheckBox @Checked;

        public CheckBox GetChecked()
        {
            return @Checked;
        }

        public void SetChecked(CheckBox value)
        {
            @Checked = value;
        }

        public override string ToString()
        {
            return Name + " " + Department;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

