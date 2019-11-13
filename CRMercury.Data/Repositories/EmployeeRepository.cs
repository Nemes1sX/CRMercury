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
        public EmployeeRepository(CRMercuryContext context)
            : base(context)
        {
        }

    }
}