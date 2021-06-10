using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.ApplicationCore.Entities
{
   public class LeaveType : AuditableEntity
    {
        
        public string Name { get; set; }
        public int Duration { get; set; }
        public ICollection<Leave> Leaves { get; set; }
    }
}
