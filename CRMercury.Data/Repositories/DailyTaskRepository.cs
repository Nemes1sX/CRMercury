using CRMecury.Data.Repositories;
using CRMercury.Data.Context;
using CRMercury.Data.Interfaces;
using CRMercury.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMercury.Data.Repositories
{
    public class DailyTaskRepository : GenericRepository<DailyTask>, IDailyTaskRepository
    {
        public DailyTaskRepository(CRMercuryContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<DailyTask>> GetAllTasks()
        {
            return await _context.DailyTasks.AsNoTracking().Include(e => e.Employee).Include(c => c.Company).ToListAsync();
        }
        public async Task<DailyTask> FindTask(int id)
        {
            return await _context.DailyTasks.SingleOrDefaultAsync(t => t.id == id);
        }
    }
}