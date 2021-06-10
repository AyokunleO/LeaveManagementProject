using LeaveMgt.Views.StaffViews.Employee;
using LeaveMgt.Views.StaffViews.LineManager;
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
    public partial class StaffLogInPage : ContentPage
    {
        public StaffLogInPage()
        {
            InitializeComponent();
            RolePicker.Items.Add("CEO");
            RolePicker.Items.Add("LineManager");
            RolePicker.Items.Add("Employee");
        }

        private void RolePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var roles = RolePicker.Items[RolePicker.SelectedIndex];
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LineManagerAppShell();
        }
    }
}