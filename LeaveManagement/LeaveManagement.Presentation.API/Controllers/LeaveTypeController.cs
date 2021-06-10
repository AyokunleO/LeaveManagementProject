using LeaveManagement.ApplicationCore.DTOs;
using LeaveManagement.ApplicationCore.Interfaces.Services;
using LeaveManagement.Presentation.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Presentation.API.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _leaveTypeService.GetAllLeaveTypes());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var leaveType = await _leaveTypeService.GetLeaveType(id);
            if (leaveType != null)
                return Ok(leaveType);

            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostAsync([FromBody] LeaveTypeViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Oops! Something went wrong");

            var leaveType = new LeaveTypeDTO
            {
                Name = model.LeaveTypeName,
                Duration = model.Duration
            };
            var leavetypeId = await _leaveTypeService.AddLeaveType(leaveType);

            if (leavetypeId != null)
                return CreatedAtAction("Get", new { Id = leavetypeId }, model);

            return BadRequest();
        }

        [HttpDelete]
        [Route("delete_{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _leaveTypeService.RemoveLeaveType(id);

            return NoContent();
        }
    }
}
