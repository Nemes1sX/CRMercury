using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CRMercury.App.Interfaces;
using CRMercury.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMercury.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
             return Ok(await _employeeService.GetAllEmployees());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult>  Create(EmployeeViewModel employee)
        {     
             bool success = await _employeeService.AddEmployee(employee);
            if (success)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeService.GetEmployeeData(id);

            if (employee.Employee != null)
                return Ok(employee);
            else
                return NotFound();
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult>  Edit(int id, EmployeeViewModel employee)
        {
            await _employeeService.UpdateEmployee(id, employee);

            return NoContent();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
             await _employeeService.DeleteEmployee(id);

            return NoContent();
        }

    }
}
