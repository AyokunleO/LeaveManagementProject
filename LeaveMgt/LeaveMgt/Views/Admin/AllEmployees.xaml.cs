using LeaveMgt.Models;
using LeaveMgt.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeaveMgt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllEmployees : ContentPage
    {
        public AllEmployees()
        {
            InitializeComponent();
        }

        private async void Employee_Select(object sender, SelectionChangedEventArgs e)
        {
            var employee = e.CurrentSelection.FirstOrDefault() as EmployeeModel;
            if (employee == null)
                return;

            await Navigation.PushModalAsync(new EmployeeInfo(employee));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}