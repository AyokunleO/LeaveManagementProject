using LeaveManagement.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeService
    {
       Task<EmployeeDTO> GetUser(ClaimsPrincipal principal);
        Task<EmployeeDTO> GetUser(string userId);
        Task<string> GetUserId(ClaimsPrincipal principal);
        IEnumerable<EmployeeDTO> GetUsers();
        Task<string> AddUser(AddEmployeeDTO user);
        Task<bool> LogInUser(LogInDTO model);
        Task LogOutUser();
        //Task RemoveUser(ClaimsPrincipal principal);
    }
}
