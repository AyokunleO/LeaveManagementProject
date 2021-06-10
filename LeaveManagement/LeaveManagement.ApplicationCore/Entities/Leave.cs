using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.ApplicationCore.Entities
{
    public class Leave : AuditableEntity
    {
        public LeaveType LeaveType { get; set; }
        public string LeaveTypeId { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
