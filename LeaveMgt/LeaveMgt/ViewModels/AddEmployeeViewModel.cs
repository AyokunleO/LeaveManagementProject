using LeaveMgt.API_Services.EmployeeServices;
using LeaveMgt.Models;
using LeaveMgt.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LeaveMgt.ViewModels
{
    public class AddEmployeeViewModel : BaseViewModel
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged(); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        private object userRole;
        public object UserRole
        {
            get { return userRole; }
            set { userRole = value; OnPropertyChanged(); }
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; OnPropertyChanged(); }
        }

        private object telephone;
        public object Telephone
        {
            get { return telephone; }
            set { telephone = value; OnPropertyChanged(); }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged(); }
        }
        private DateTime employmentDate;
        public DateTime EmploymentDate
        {
            get { return employmentDate; }
            set { employmentDate = value; OnPropertyChanged(); }
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

        public Command AddEmployeeCommand { get; set; }
        public AddEmployeeViewModel()
        {
            AddEmployeeCommand = new Command(async () => await AddEmployeeCommandAsync());
        }

        private async Task AddEmployeeCommandAsync()
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
                else
                {
                    var employeeService = new EmployeeService();
                    var Result = await employeeService.Addemployee(FirstName, LastName, Address, DateOfBirth, EmploymentDate, Email, Telephone, UserRole);
            //        if(Result)
            //        {

            //            Preferences.Set("Email", Email);
                        
            //            await Application.Current.MainPage.DisplayAlert("Success", "Data Saved Successfully", "OK");
            //            await Application.Current.MainPage.Navigation.PushModalAsync(new AddEmployee());
            //}
            //        else
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Email or Password", "OK");
            //}
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