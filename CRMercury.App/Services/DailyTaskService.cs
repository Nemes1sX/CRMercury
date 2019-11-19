using CRMercury.App.Converters;
using CRMercury.App.Dto;
using CRMercury.App.Interfaces;
using CRMercury.App.ViewModels;
using CRMercury.Data.Interfaces;
using CRMercury.Data.Models;
using CRMercury.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CRMercury.App.Services
{

    public class DailyTaskService : IDailyTaskService
    {

        private IDailyTaskRepository _taskRepository;
        private DailyTaskConverter _taskConverter;

        public DailyTaskService(IDailyTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _taskConverter = new DailyTaskConverter();
        }

        public async Task<DailyTaskListViewModel> GetAll()
        {
            IEnumerable<DailyTask> tasks = await _taskRepository.GetAllTasks();

            return _taskConverter.ToDailyTaskListViewModel(tasks);
        }
        public async Task<bool> AddTask(DailyTaskViewModel task)
        {
            DailyTask taskTemp =  _taskConverter.ToDailyTask(task.DailyTask);
            bool taskValid = true;
            if (taskValid)
                await _taskRepository.AddAsync(taskTemp);
            return taskValid;
        }

        public async Task<DailyTaskViewModel> FindTask(int id)
        {
            if (!await _taskRepository.ExistsAsync(id))
            {
                return new DailyTaskViewModel();
            }

            DailyTask task = await _taskRepository.FindTask(id);

            return _taskConverter.ToDailyTaskViewModel(task);
        }

        public async Task UpdateTask(DailyTaskViewModel dailytask, int id)
        {
            DailyTask dailytaskTemp = _taskConverter.ToDailyTask(dailytask.DailyTask);
            if (await _taskRepository.ExistsAsync(id))
            {
               dailytaskTemp.id = id;
                await _taskRepository.UpdateAsync(dailytaskTemp);
            }
        }
        public async Task DeleteTask(int id)
        {
            if (await _taskRepository.ExistsAsync(id))
                await _taskRepository.DeleteAsync(id);
          
        }
    }

}