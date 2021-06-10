using LeaveManagement.ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Infrastructure.DAL.DBContext
{
    public static class SeedData
    {
        public async static Task AddEmployees(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            if(await userManager.FindByEmailAsync("Admin@sdsd.com") == null)
            {
                var emp = new Employee
                {
                    FirstName = "Ayokunle",
                    LastName = "Onadiji",
                    Email = "Admin@sdsd.com",
                    UserName = "Admin@sdsd.com",
                    PhoneNumber = "07031056050",
                    Address = "Glenridge dr, Landover hills, MD",
                    
                };

                var result = await userManager.CreateAsync(emp, "Admin@123");

                if (result.Succeeded)
                {

                    await CreateRoles(roleManager);
                    await userManager.AddToRoleAsync(emp, "Administrator");
                }
            }
        }

        private async static Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Administrator" });
                await roleManager.CreateAsync(new IdentityRole { Name = "CEO" });
                await roleManager.CreateAsync(new IdentityRole { Name = "LineManager" });
                await roleManager.CreateAsync(new IdentityRole { Name = "StaffMember" });
            }
        }

        public async static Task AddLeaveTypes(LeaveManagementDbContext dbContext)
        {
            if (!dbContext.LeaveTypes.Any())
            {
                var leaveTypes = new List<LeaveType>()
            {
                new LeaveType{Name = "Sick Leave"},
                new LeaveType { Name = "Casual"},
                new LeaveType{Name = "Annual Leave"}
            };
                await dbContext.LeaveTypes.AddRangeAsync(leaveTypes);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
