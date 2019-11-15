using CRMercury.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMercury.Data.Interfaces {
    public interface ITaskRepository : IGenericRepository<CRMercury.Data.Models.Task> {
            
        System.Threading.Tasks.Task<IEnumerable<CRMercury.Data.Models.Task>> GetAllTasks();

        System.Threading.Tasks.Task<CRMercury.Data.Models.Task> FindTask(int id);
    }
}