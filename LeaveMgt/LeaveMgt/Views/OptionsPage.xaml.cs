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
    public partial class OptionsPage : ContentPage
    {
        public OptionsPage()
        {
            InitializeComponent();
            var images = new List<string>
            {
                "lady1.jpg",
                "office.jpg",
                "office1.jpg"
            };
            MainCarouselView.ItemsSource = images;
        }

        private void admin_clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new AdminLogInPage());
        }

        private void staff_clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new StaffLogInPage());
        }
    }
}