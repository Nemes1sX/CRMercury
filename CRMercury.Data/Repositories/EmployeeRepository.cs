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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SimpleCRMContext context)
            : base(context)
        {
        }

        private Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Employee, Role> EmployeeQuery()
        {
            return _context.Employees
                .AsNoTracking();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeListAsync()
        {
            return await this.EmployeeQuery().ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await this.EmployeeQuery().FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}