using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using XLabs.Forms.Controls;

namespace GroceryList1
{
    public class GroceryListPage : ContentPage
    {
        public GroceryListPage()
        {
            ObservableCollection<ListItem> list = new ObservableCollection<ListItem>();

            ListView listView = new ListView
            {
                ItemsSource = list,
                ItemTemplate = new DataTemplate(typeof(ItemCell)),
                RowHeight = ItemCell.RowHeight
            };

            StackLayout layout = new StackLayout();
            layout.Children.Add(listView);
            Entry eName = new Entry
            {
                Placeholder = "Enter an Item",
                PlaceholderColor = Color.Gray,
                BackgroundColor = Color.PaleTurquoise

            };
            Picker pckDept = new Picker
            {
                WidthRequest = 300,
                Title = "Select a Department",
                Items = {"Bakery", "Beverages", "Bulk", "Canned Goods", 
                        "Dairy", "Deli", "Dry Goods",
                        "Frozen", "Household Items", "Meat/Seafood",
                        "Produce", "Other" },    
                BackgroundColor = Color.PaleTurquoise
            };


            Button btnNew = new Button { Text = "Add To List" };

            
            

            btnNew.Clicked += (sender, e) =>
            {
                //Department selected, and item not blank. Add name and dept. 
                if (eName.Text != null  && pckDept.SelectedIndex != -1)
                {
                    ListItem l = new ListItem { Name = eName.Text, Department = pckDept.SelectedItem.ToString()};
                    list.Add(l);
                    eName.Placeholder = "Enter an Item";
                    eName.Text = "";
                    pckDept.SelectedItem = "Select a Department";
                }

                //item entered but dept left blank. Add as other
                else if (eName.Text != null && pckDept.SelectedIndex == -1)
                {
                    ListItem l = new ListItem { Name = eName.Text, Department = "Other" };
                    list.Add(l);
                    eName.Placeholder = "Enter an Item";
                    eName.Text = "";
                    pckDept.SelectedItem = "Select a Department";
                }


            };

            layout.Children.Add(eName);
            layout.Children.Add(pckDept);
            layout.Children.Add(btnNew);

            Title = "Grocery List";

            Content = layout;
        }
    }
}
