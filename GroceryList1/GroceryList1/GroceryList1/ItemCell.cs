using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace GroceryList1
{
    public class ItemCell : ViewCell
    {
        public const int RowHeight = 100;

        public ItemCell()
        {
            Label lblName = new Label { FontAttributes = FontAttributes.Bold };
            lblName.SetBinding(Label.TextProperty, "Name");
            Label lblDepartment = new Label { FontAttributes = FontAttributes.Italic };
            lblDepartment.SetBinding(Label.TextProperty, "Department");

            CheckBox Checked = new CheckBox()
            {
                TextColor = Color.Black,
                Checked = false
            };

            Grid TableRow = new Grid();
            TableRow.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            TableRow.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
            TableRow.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });

            TableRow.Children.Add(lblName, 0, 0);
            TableRow.Children.Add(lblDepartment, 1, 0);
            TableRow.Children.Add(Checked, 2, 0);

            View = new StackLayout

            {
                Spacing = 2,
                Padding = 5,
                Children = { TableRow }//lblName, lblDepartment, Checked }
            };
            

            MenuItem mi = new MenuItem { Text = "Delete", IsDestructive = true };
            mi.Clicked += (sender, e) =>
            {
                ListView parent = (ListView)this.Parent;
                ObservableCollection<ListItem> list = (ObservableCollection<ListItem>)parent.ItemsSource;
                list.Remove(this.BindingContext as ListItem);
            };
            ContextActions.Add(mi);
        }




    }
}
