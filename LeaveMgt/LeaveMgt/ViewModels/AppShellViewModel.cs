using LeaveMgt.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LeaveMgt.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        public AppShellViewModel()
        {
            Application.Current.MainPage = new AdminLogInPage();
        }
    }
}
