using ClosedXML.Excel;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace Warehouse
{
    public partial class DataPage : ContentPage
    {
        public class Item
        {
            public Item(string name, string amount)
            {
                this.name = name;
                this.amount = amount;
            }

            public string name { get; set; }
            public string amount { get; set; }
        }
        public class Order
        {
            public Order(int number, List<Item> items)
            {
                this.number = number;
                this.items = items;
            }

            public int number { get; set; }

            public List<Item> items { get; set; }
        }
        public DataPage(IXLWorksheet ws)
        { 
            InitializeComponent();

            // create list of orders
            int rows = ws.LastRowUsed().RowNumber();
            int cols = ws.LastColumnUsed().ColumnNumber();

            List<Order> orders = new List<Order>();
            for (int i = 2; i <= rows - 1; i++)
            {
                int orderNumber = (int)ws.Cell(i, 1).Value;
                List<Item> items = new List<Item>();
                for (int j = 2; j <= cols - 1; j++)
                {
                    Item item = new Item(ws.Cell(1, j).Value.ToString(), ws.Cell(i, j).Value.ToString());
                    items.Add(item);
                }
                
                Order order = new Order(orderNumber, items);
                orders.Add(order);
            }

            Orders.ItemsSource = orders;
    
        }

        
        public async void listViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var order = e.SelectedItem as Order;
            await Navigation.PushAsync(new OrderPage(order));
        }
        
    }
}