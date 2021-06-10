using LeaveManagement.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.ApplicationCore.Interfaces.Services
{
    public interface ILeaveService
    {
        Task<LeaveDTO> GetLeave(string id);
        Task<IEnumerable<LeaveDTO>> GetLeaves(int count = 3);
        Task RemoveLeave(string id);
        Task<string> AddLeave(LeaveDTO leave);
        Task UpdateLeave(LeaveDTO leave);
    }
}
