using Microsoft.EntityFrameworkCore;
using CRMercury.Data.Context;
using CRMercury.Data.Interfaces;
using CRMercury.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMercury.Data.Repositories 
{ 
    public class TaskRepository : GenericRepository<Task>, ITaskRepository 
    {
        public TaskRepository(CRMercuryContext context)
            : base(context)
        {
        }
        private Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Employee, Role> TaskQuery()
        {
            return _context.Tasks.Include(e => e.Employee).Include(c => c.Company)
                .AsNoTracking();
        }
        public async Task<IEnumerable<Task>> GetAllTasks()
        {
            return await this.TaskQuery().ToListAysnc();
        }
        public async Task<Task> FindTask(int id)
        {
            return await this.TaskQuery().FirstOrDefaultAsync(t => t.id == id);
        }
    } 
}