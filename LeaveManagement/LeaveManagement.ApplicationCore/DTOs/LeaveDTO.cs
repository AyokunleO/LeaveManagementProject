using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.ApplicationCore.DTOs
{
    public class LeaveDTO
    {
        public string Id { get; set; }
        public string LeaveType { get; set; }
        public string LeaveTypeId { get; set; }
        public string Employee { get; set; }
        public string EmployeeId { get; set; }
        public string Status { get; set; }
    }
}
