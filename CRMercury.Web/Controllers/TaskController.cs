using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using CRMercury.Interfaces;
using CRMercury.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRMercury.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase {

        private readonly ITask obj;

        public TaskController(ITask _obj)
        {
            obj = _obj;
        }
        [HttpGet]
        [Route("Index")]
        public IEnumerable<Task> Index(){

            return obj.GetAll();
        }
        [HttpPost]
        [Route("Create")]
        public int Create ([FromBody] Task task)
        {
            return obj.AddTask(task);
        }
        [HttpGet]
        [Route("Details/{id}")]
        public Task Employee(int id)
        {
            return obj.FindTask(id); 
        }
        [HttpPut]
        [Route("Edit")]
        public int Edit([FromBody]Task task)
        {
            return obj.UpdateTask(task);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(int id)
        {
            return obj.DeleteTask(id);
        }
    }

}