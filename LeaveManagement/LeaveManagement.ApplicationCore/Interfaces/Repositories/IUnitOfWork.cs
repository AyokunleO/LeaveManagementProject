using LeaveManagement.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.ApplicationCore.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Leave> Leaves { get; }
        public IRepository<LeaveType> LeaveTypes { get; }
        Task<int> Complete();
    }
}
