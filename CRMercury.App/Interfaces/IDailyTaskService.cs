using CRMercury.Data.Models;
using CRMercury.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMercury.App.Interfaces 
{ 
    public interface IDailyTaskService 
    {
        Task<DailyTaskListViewModel> GetAll();

        Task<bool> AddTask(DailyTaskViewModel task);

        Task<DailyTaskViewModel> FindTask(int id);

        Task UpdateTask(DailyTaskViewModel task, int id);

        Task DeleteTask(int id);
    }  

}
