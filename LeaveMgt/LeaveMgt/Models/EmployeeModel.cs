using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveMgt.Models
{
    public class EmployeeModel
    {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string DateCreated { get; set; }
            public object UserRole { get; set; }
            public DateTime DateOfBirth { get; set; }
            public object Telephone { get; set; }
            public string Address { get; set; }
            public DateTime EmploymentDate { get; set; }
            public string Password { get; set; }

    }
}
