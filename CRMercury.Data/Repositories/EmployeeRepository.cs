using CRMecury.Data.Repositories;
using CRMercury.Data.Context;
using CRMercury.Data.Interfaces;
using CRMercury.Data.Models;

namespace CRMercury.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CRMercuryContext context)
            : base(context)
        {
        }


    }
}