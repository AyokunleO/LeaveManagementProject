using LeaveMgt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveMgt.ViewModels
{
    public class EmployeeInfoViewModel :BaseViewModel
    {
        private EmployeeModel selectedEmployee;

        public EmployeeModel SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; OnPropertyChanged(); }
        }

        public EmployeeInfoViewModel(EmployeeModel employee)
        {
            SelectedEmployee = employee;
        }
        public EmployeeInfoViewModel()
        {
                
        }
    }
}
