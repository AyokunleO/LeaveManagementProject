using LeaveManagement.ApplicationCore.Interfaces.Repositories;
using LeaveManagement.ApplicationCore.Interfaces.Services;
using LeaveManagement.ApplicationCore.Services;
using LeaveManagement.Infrastructure.DAL.Repository;
using LeaveManagement.Infrastructure.DAL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Infrastructure.IOC
{
    public static class LeaveManagementDependencyContainer
    {
        public static IServiceCollection AddLeaveManagementService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILeaveService, LeaveService>();
            services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
