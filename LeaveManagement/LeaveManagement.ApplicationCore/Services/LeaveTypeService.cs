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
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeaveTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> AddLeaveType(LeaveTypeDTO model)
        {
            var leaveType = new LeaveType
            {
                Name = model.Name,
                Duration = model.Duration
            };
            await _unitOfWork.LeaveTypes.Add(leaveType);
            await _unitOfWork.Complete();
            return leaveType.Id;
        }

        public async Task<IEnumerable<LeaveTypeDTO>> GetAllLeaveTypes(int count = 3)
        {
            var leaveTypes = await _unitOfWork.LeaveTypes.GetAll();
            return leaveTypes.Select(l => Map(l)).ToList();
        }

        public async Task<LeaveTypeDTO> GetLeaveType(string id)
        {
            var leaveType = await _unitOfWork.LeaveTypes.Find(id);
            return Map(leaveType);
        }

        public async Task RemoveLeaveType(string id)
        {
            var leaveType = await _unitOfWork.LeaveTypes.Find(id);
            _unitOfWork.LeaveTypes.Remove(leaveType);
            await _unitOfWork.Complete();
        }

        private static LeaveTypeDTO Map(LeaveType l)
        {
            return new LeaveTypeDTO
            {
                Id = l.Id,
                Name = l.Name,
                Duration = l.Duration
            };
        }
    }
}
