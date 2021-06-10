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
    public partial class AddEmployee : ContentPage
    {
        public AddEmployee()
        {
            InitializeComponent();
            RolePicker.Items.Add("CEO");
            RolePicker.Items.Add("LineManager");
            RolePicker.Items.Add("Employee");
        }

        private void SelectedDate(object sender, DateChangedEventArgs e)
        {
           // MainLabel.Text = e.NewDate.ToString();
        }

        private void RolePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var roles = RolePicker.Items[RolePicker.SelectedIndex];
        }

        private void ReportOfficer_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}