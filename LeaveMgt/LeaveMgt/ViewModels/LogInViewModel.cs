using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeaveMgt.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public Command LogInCommand { get; set; }
        public LogInViewModel()
        {
            LogInCommand = new Command(async () => await LogInCommandAsync());
        }

        private async Task LogInCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                if (string.IsNullOrEmpty(Email))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Email cannot be empty", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(Password))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password cannot be empty", "OK");
                    return;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
