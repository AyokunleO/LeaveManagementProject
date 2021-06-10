using LeaveMgt.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LeaveMgt.ViewModels
{
    public class EmployeeAppShellViewModel : BaseViewModel
    {
        public EmployeeAppShellViewModel()
        {
            Application.Current.MainPage = new StaffLogInPage();
        }
    }
}
