using LeaveManagement.ApplicationCore.DTOs;
using LeaveManagement.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LeaveManagement.Presentation.API.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("")]
       //// [Authorize(Roles ="Administrator")]
        public IActionResult Get()
        {
           return Ok( _employeeService.GetUsers());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var employee = await _employeeService.GetUser(id);
            if (employee != null)
                return Ok(employee);

            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] AddEmployeeDTO emp)
        {
            var result = await _employeeService.AddUser(emp);
            if (result != null)
                return CreatedAtAction(nameof(GetAsync), new { id = result}, emp);

            return BadRequest();
        }


        //[HttpDelete]
        //[Route("delete_{id}")]
        //public async Task<IActionResult> Remove(string id)
        //{
        //    await _employeeService.RemoveUser(id);

        //    return NoContent();
        //}
    }
}
