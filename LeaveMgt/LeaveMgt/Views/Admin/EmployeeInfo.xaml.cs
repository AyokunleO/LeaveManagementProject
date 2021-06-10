using LeaveMgt.Models;
using LeaveMgt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeaveMgt.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeInfo : ContentPage
    {
        EmployeeInfoViewModel employeeInfo;
        public EmployeeInfo(EmployeeModel employee)
        {
            employeeInfo = new EmployeeInfoViewModel(employee);
            InitializeComponent();
            this.BindingContext = employeeInfo;
        }
    }
}