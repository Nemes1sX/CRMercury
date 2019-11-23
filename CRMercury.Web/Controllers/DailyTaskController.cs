using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CRMercury.App.Interfaces;
using CRMercury.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRMercury.Web.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class DailyTaskController : ControllerBase {

        private IDailyTaskService _taskService;

        public DailyTaskController(IDailyTaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index(){

            return Ok(await _taskService.GetAll());
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create (DailyTaskViewModel task)
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
            var dailytask = await _taskService.FindTask(id);

            if (dailytask.DailyTask != null)
                return Ok(dailytask);
            else
                return NotFound();
        }
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id, DailyTaskViewModel dailytask)
        {
             await _taskService.UpdateTask(dailytask, id);

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