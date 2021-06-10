using LeaveManagement.ApplicationCore.DTOs;
using LeaveManagement.ApplicationCore.Entities;
using LeaveManagement.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Infrastructure.DAL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EmployeeService(UserManager<Employee> userManager, SignInManager<Employee> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<string> AddUser(AddEmployeeDTO user)
        {
            var emp = new Employee
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.Email,
                EmploymentDate = user.EmploymentDate,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Telephone = user.Telephone               
            };

            var result = await _userManager.CreateAsync(emp, user.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(user.UserRole))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = user.UserRole });
                }
                await _userManager.AddToRoleAsync(emp, user.UserRole);
            }
            return emp.Id;
        }

        public async Task<EmployeeDTO> GetUser(ClaimsPrincipal principal)
        {
            var emp = await _userManager.GetUserAsync(principal);
            return new EmployeeDTO
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                UserRole = emp.UserRole,
                EmploymentDate = emp.EmploymentDate,
                Address = emp.Address,
                DateCreated = emp.DateCreated.ToString("D")
            };
        }

        public async Task<EmployeeDTO> GetUser(string id)
        {
            var emp = await _userManager.FindByIdAsync(id);
            return new EmployeeDTO
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                UserRole = emp.UserRole,
                EmploymentDate = emp.EmploymentDate,
                Address = emp.Address,
                DateCreated = emp.DateCreated.ToString("D")
            };
        }

        public async Task<string> GetUserId(ClaimsPrincipal principal)
        {
        var emp = await GetUser(principal);
        return emp.Id;
    }

        public IEnumerable<EmployeeDTO> GetUsers()
        {
            var employees = _userManager.Users;
            return employees.Select(e => Map(e));
         
        }

        public async Task<bool> LogInUser(LogInDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return true;
            } return false;
        }

        public async Task LogOutUser()
        {
           await _signInManager.SignOutAsync();
        }

        //public async Task RemoveUser(string id)
        //{
        //    _userManager.
        //}

        private static EmployeeDTO Map(Employee model)
        {
            return new EmployeeDTO
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                EmploymentDate = model.EmploymentDate,
                Telephone = model.Telephone,
                UserRole = model.UserRole
            };
        }
    }
}
