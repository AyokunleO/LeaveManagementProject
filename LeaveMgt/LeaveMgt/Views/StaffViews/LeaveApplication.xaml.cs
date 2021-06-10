using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeaveMgt.Views.StaffViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaveApplication : ContentPage
    {
        public LeaveApplication()
        {
            InitializeComponent();
            LeavePicker.Items.Add("Casual Leave");
            LeavePicker.Items.Add("Sick Leave");
            LeavePicker.Items.Add("Annual Leave");

            //RequestPicker.Items.Add("CEO");
            //RequestPicker.Items.Add("Line Manager1");
            //RequestPicker.Items.Add("Line Manager2");
        }

        private void LeavePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var roles = LeavePicker.Items[LeavePicker.SelectedIndex];

        }

        private void SelectedDate(object sender, DateChangedEventArgs e)
        {
           
        }

        //private void RequestPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var roles = RequestPicker.Items[RequestPicker.SelectedIndex];
        //}
    }
}