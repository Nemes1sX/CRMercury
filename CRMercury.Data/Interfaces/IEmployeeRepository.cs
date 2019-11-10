using CRMercury.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMercury.Data.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeeListAsync();
        Task<Employee> GetEmployeeAsync(int id);
    }
}
