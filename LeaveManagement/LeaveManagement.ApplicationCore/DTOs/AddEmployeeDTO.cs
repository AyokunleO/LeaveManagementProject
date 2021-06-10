using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.ApplicationCore.DTOs
{
    public class AddEmployeeDTO : EmployeeDTO
    {
        public string Password { get; set; }
    }
}
