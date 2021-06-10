using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveMgt.Models
{
   public class LeaveModel
    {
            public string Id { get; set; }
            public string LeaveType { get; set; }
            public object LeaveTypeId { get; set; }
            public string Employee { get; set; }
            public object EmployeeId { get; set; }
            public string Status { get; set; }

    }
}
