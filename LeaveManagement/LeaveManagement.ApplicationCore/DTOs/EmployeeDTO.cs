using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.ApplicationCore.DTOs
{
    public class EmployeeDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateCreated { get; set; }
        public string UserRole { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public DateTimeOffset EmploymentDate { get; set; }
    }
}
