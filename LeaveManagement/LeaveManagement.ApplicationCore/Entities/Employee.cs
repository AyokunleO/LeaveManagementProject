
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.ApplicationCore.Entities
{
    public class Employee :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
       // public DateTimeOffset DateModified { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset EmploymentDate { get; set; }
        public bool IsDeleted { get; set; }
        public string UserRole { get; set; }
        public ICollection<Leave> Leaves { get; set; }
    }
}
