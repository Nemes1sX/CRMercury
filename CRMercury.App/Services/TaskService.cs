using CRMercury.App.Converters;
using CRMercury.App.Dto;
using CRMercury.App.Interfaces;
using CRMercury.App.ViewModels;
using CRMercury.Data.Interfaces;
using CRMercury.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CRMercury.App.Services
{

    public class TaskService : ITaskService
    {

        private ITaskRepository _taskRepostiory;
        private TaskConverter _taskConverter;

        public TasksService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _taskConverter = new TaskConverter();
        }

        public async Task<TaskViewModel> GetAllTasks()
        {
            IEnumerable<Task> tasks = await _taskRepostiory.GetAllTasks();

            return _taskConverter.ToTaskListViewModel(tasks);
        }
        public async Task<bool> AddTask(TaskViewModel task)
        {
            Task taskTemp = _taskConverter.ToTask(task.Task);
            bool taskValid = true;
            if (taskValid)
                await _taskRepostiory.AddAsync(taskTemp);
            return taskValid;
        }

        public async Task<TaskViewModel> FindTask(int id)
        {
            if (!await _taskRepository.ExistsAsync(id))
            {
                return new TaskViewModel();
            }

            Task task = await _taskRepository.GetTaskAsync(id);

            return _taskConverter.ToTaskViewModel(task);
        }

        public int UpdateTask(int id, TaskViewModel task)
        {
            Task taskTemp = _taskConverter.ToTask(task.Task);
            if (await _employeeRepository.ExistsAsync(id))
            {
                taskTemp.Id = id;
                await _employeeRepository.UpdateAsync(taskTemp);
            }
        }
        public async Task DeleteTask(int id)
        {
            if (_taskRepostiory.ExistsAysnc(id))
                await _taskRepostiory.DeleteTask(id);
          
        }
    }

}