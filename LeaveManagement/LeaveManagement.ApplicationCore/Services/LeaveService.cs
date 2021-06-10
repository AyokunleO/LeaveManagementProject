using LeaveManagement.ApplicationCore.DTOs;
using LeaveManagement.ApplicationCore.Entities;
using LeaveManagement.ApplicationCore.Interfaces.Repositories;
using LeaveManagement.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.ApplicationCore.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string[] includes = new string[] { "Employee", "LeaveType" };

        public LeaveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> AddLeave(LeaveDTO model)
        {
            var leave = new Leave
            {
                EmployeeId = model.EmployeeId,
                Status = model.Status,
                LeaveTypeId = model.LeaveTypeId
            };
            await _unitOfWork.Leaves.Add(leave);
            await _unitOfWork.Complete();
            return leave.Id;
        }

        public async Task<LeaveDTO> GetLeave(string id)
        {
            return Map(await _unitOfWork.Leaves.Get(l => l.Id == id, includes));
        }

        public async Task<IEnumerable<LeaveDTO>> GetLeaves(int count = 20)
        {
            var leaves = await _unitOfWork.Leaves.GetAll(includes);
            return leaves.Select(l => Map(l)).ToList();
        }

        public async Task RemoveLeave(string id)
        {
            var leave = await _unitOfWork.Leaves.Find(id);
            _unitOfWork.Leaves.Remove(leave);

            await _unitOfWork.Complete();
        }

        public async Task UpdateLeave(LeaveDTO leave)
        {
            var currentLeave = await _unitOfWork.Leaves.Get(l => l.Id == leave.Id, includes);
            currentLeave.Status = leave.Status;
            _unitOfWork.Leaves.Update(currentLeave);
           await _unitOfWork.Complete();
        }

        private static LeaveDTO Map (Leave model)
        {
            return new LeaveDTO
            {
                Id = model.Id,
                Employee = $"{model.Employee.FirstName} {model.Employee.LastName}",
                LeaveType = model.LeaveType.Name,
                Status = model.Status
            };
        }
    }
}
