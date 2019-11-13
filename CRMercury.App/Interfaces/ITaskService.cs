using CRMercury.Data.Models;
using CRMercury.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMercury.Data.Interfaces 
{ 
    public interface ITaskService 
    {
        Task<TaskListViewModel> GetAll();

        Task<bool> AddTask(TaskViewModel task);

        Task<TaskViewModel> FindTask(int id);

        Task UpdateTask(TaskViewModel task, int id);

        Task DeleteTask(int id);
    }  

}
