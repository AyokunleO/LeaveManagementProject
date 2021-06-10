using LeaveMgt.Views;
using LeaveMgt.Views.Admin;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeaveMgt
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new OptionsPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
