using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Warehouse;
using static Warehouse.DataPage;

namespace Warehouse
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public OrderPage(Order order)
        {
            InitializeComponent();

            Items.ItemsSource = order.items;


        }
    }
}