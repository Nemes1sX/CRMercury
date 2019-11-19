using CRMecury.Data.Repositories;
using CRMercury.Data.Context;
using CRMercury.Data.Interfaces;
using CRMercury.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMercury.Data.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(CRMercuryContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Company>> GetListAsyncSearch(string search)
        {
            IQueryable<Company> query = _context.Companies;

            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.name.Contains(search)
                    || c.ceoname.Contains(search));
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetListAsyncSort(string sort)
        {
            IQueryable<Company> query = _context.Companies;
            switch (sort)
            {
                case "name":
                    query = query.OrderBy(c => c.name);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(c => c.name);
                    break;
                case "ceoname":
                    query = query.OrderBy(c => c.ceoname);
                    break;
                case "ceoname_desc":
                    query = query.OrderByDescending(c => c.ceoname);
                    break;
            }
            return await query.ToListAsync();
        }
    }
}