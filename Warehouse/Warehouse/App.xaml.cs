using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Warehouse
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // add code to request permission here
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
