using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using CRMercury.App.Interfaces;
using CRMercury.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRMercury.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase {

        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index(){

            return Ok(await _taskService.GetAllTasks());
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create (TaskViewModel task)
        {
             bool success = await _taskService.AddTask(task);
            if (success)
                return Ok();
            else
                return BadRequest();
        }
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> FindTask(int id)
        {
            var task = await _taskService.FindTask(id);

            if (employee.Employee != null)
                return Ok(task);
            else
                return NotFound();
        }
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id, TaskViewModel task)
        {
             await _taskService.UpdateTask(id, task);

            return NoContent();
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             await _taskService.DeleteTask(id);

            return NoContent();
        }
    }

}