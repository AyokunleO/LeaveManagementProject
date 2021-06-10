using LeaveManagement.ApplicationCore.Entities;
using LeaveManagement.ApplicationCore.Interfaces.Repositories;
using LeaveManagement.Infrastructure.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Infrastructure.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeaveManagementDbContext _dbContext;

        public IRepository<Leave> Leaves { get; private set;
    }

    public IRepository<LeaveType> LeaveTypes { get; private set; }

    public UnitOfWork(IRepository<Leave> leaveRepository, IRepository<LeaveType> leaveTypeRepository, LeaveManagementDbContext dbContext)
        {
            Leaves = leaveRepository;
            LeaveTypes = leaveTypeRepository;
            _dbContext = dbContext;
        }
        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
