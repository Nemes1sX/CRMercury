using CRMercury.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMercury.Interfaces
{
    public interface ICompany
    {
        IEnumerable<Company> GetAll();
        int AddCompany(Company company);
        int UpdateCompany(Company company);
        Company FindCompany(int id);
        int DeleteCompany(int id);
        IEnumerable<Company> Sort(string sort);
         IEnumerable<Company> Search(string key);

    }
}
