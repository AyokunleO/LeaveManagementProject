using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.ApplicationCore.DTOs
{
    public class LeaveTypeDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
    }
}
