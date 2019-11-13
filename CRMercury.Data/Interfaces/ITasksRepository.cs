using CRMercury.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CRMercury.Interfaces {
    public interface ITask : IGenericRepository<Task> {
            
        Task<IEnumerable<Task>> GetAllTasks();

        Task<Task> FindTask(int id);
    }
}