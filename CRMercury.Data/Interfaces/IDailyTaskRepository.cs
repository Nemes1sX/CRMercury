using CRMercury.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMercury.Data.Interfaces
{
    public interface IDailyTaskRepository : IGenericRepository<DailyTask>
    {

        Task<IEnumerable<DailyTask>> GetAllTasks();

        Task<DailyTask> FindTask(int id);

    }
}