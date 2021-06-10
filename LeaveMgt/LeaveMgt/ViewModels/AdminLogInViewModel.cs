using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeaveMgt.ViewModels
{
    public class AdminLogInViewModel
    {
        public Command LogInCommand { get; set; }

        public AdminLogInViewModel()
        {
            LogInCommand = new Command(async () => await LogInCommandAsync());
        }

        private async Task LogInCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new AppShell());
        }
    }
}
