using LeaveManagement.ApplicationCore.DTOs;
using LeaveManagement.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Presentation.API.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;

        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetLeave()
        {
            return Ok(await _leaveService.GetLeaves());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var leave = await _leaveService.GetLeave(id);
            if (leave != null)
                return Ok(leave);

            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] LeaveDTO leave)
        {
            var result = await _leaveService.AddLeave(leave);
            if (result != null)
                return CreatedAtAction("GetLeave", new { Id = result }, leave);

            return BadRequest();
        }

        [HttpDelete]
        [Route("delete_{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _leaveService.RemoveLeave(id);

            return NoContent();
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateLeave([FromBody] LeaveDTO leave)
        {
           await _leaveService.UpdateLeave(leave);

            return NoContent();
        }
    }
}
