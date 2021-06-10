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
    public partial class AdminLogInPage : ContentPage
    {
        public AdminLogInPage()
        {
            InitializeComponent();
        }

        private void button_clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
        }
    }
}