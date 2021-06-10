using LeaveMgt.API_Services.EmployeeServices;
using LeaveMgt.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LeaveMgt.ViewModels
{
    public class AllEmployeeViewModel : BaseViewModel
    {
        private ObservableCollection<EmployeeModel> _allEmployees;

        public ObservableCollection<EmployeeModel> AllEmployees
        {
            get { return _allEmployees; }
            set { _allEmployees = value; OnPropertyChanged(); }
        }

        public AllEmployeeViewModel()
        {
            AllEmployees = new ObservableCollection<EmployeeModel>();
           GetAllEmployeesAsync();
        }

        private async void GetAllEmployeesAsync()
        {
            var result = await new EmployeeService().GetAll();
            AllEmployees.Clear();
            foreach (var item in result)
            {
                AllEmployees.Add(item);
            }
        }
    }
}
