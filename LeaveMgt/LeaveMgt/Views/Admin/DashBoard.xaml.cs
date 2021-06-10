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
    public partial class DashBoard : ContentPage
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void AllEmployee_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new AllEmployees());
        }

        private void AddEmployee_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new AddEmployee());
        }

        private void AllRequest_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new AllRequests());
        }
    }
}