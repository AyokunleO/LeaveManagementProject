using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Presentation.API.ViewModels
{
    public class LeaveTypeViewModel
    {
        [Required(ErrorMessage = "LeaveType Name is required")]
        public string LeaveTypeName { get; set; }
        public int Duration { get; set; }
    }
}
