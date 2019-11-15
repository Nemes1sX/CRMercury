using Microsoft.EntityFrameworkCore;
using CRMercury.Data.Context;
using CRMercury.Data.Interfaces;
using CRMercury.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRMecury.Data.Repositories;
using System.Threading.Tasks;

namespace CRMercury.Data.Repositories 
{
    public class TaskRepository : GenericRepository<CRMercury.Data.Models.Task>, ITaskRepository
    {
        public TaskRepository(CRMercuryContext context)
            : base(context)
        {
        }
     
        public async System.Threading.Tasks.Task<IEnumerable<CRMercury.Data.Models.Task>> GetAllTasks()
        {
            return await _context.Tasks.AsNoTracking().Include(e => e.Employee).Include(c => c.Company).ToListAsync();
        }
        public async System.Threading.Tasks.Task<CRMercury.Data.Models.Task> FindTask(int id)
        {
            return await _context.Tasks.SingleOrDefaultAsync(t => t.id == id);
        }
    } 
}