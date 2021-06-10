using LeaveManagement.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.ApplicationCore.Interfaces.Services
{
    public interface ILeaveTypeService
    {
        Task<LeaveTypeDTO> GetLeaveType(string id);
        Task<IEnumerable<LeaveTypeDTO>> GetAllLeaveTypes(int count = 20);
        Task<string> AddLeaveType(LeaveTypeDTO leave);
        Task RemoveLeaveType(string id);
    }
}
