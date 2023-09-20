using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Windows.Input;
using ExcelDataReader;
using System.IO;
using ClosedXML.Excel;

namespace Warehouse
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            var result = await FilePicker.PickAsync();

            var stream = await result.OpenReadAsync();
            
            XLWorkbook wb = new XLWorkbook(stream);

            IXLWorksheet ws = wb.Worksheet(1);
           
            await Navigation.PushAsync(new NavigationPage(new DataPage(ws)));
        }  
    }
}
