using LeaveMgt.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LeaveMgt.ViewModels
{
    class LMAppShellViewModel : BaseViewModel
    {
        public LMAppShellViewModel()
        {
            Application.Current.MainPage = new StaffLogInPage();
        }

    }
}
