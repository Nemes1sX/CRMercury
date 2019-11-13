using CRMercury.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMercury.Data.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<IEnumerable<Company>> GetListAsyncSort(string sort);
        Task<IEnumerable<Company>> GetListAsyncSearch(string search);
    }
}

