using CRMercury.Data.Models;
using CRMercury.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMercury.App.Services
{
	public class ICompanyService
    {
        Task<CompanyListViewModel> GetAll();
        Task<bool> AddCompany(CompanyViewModel company);
        Task UpdateCompany(CompanyViewModel company, int id);
        Task<CompanyViewModel> FindCompany(int id);
        Task DeleteCompany(int id);
        Task<CompanyListViewModel> Sort(string sort);
        Task<CompanyListViewModel> Search(string key);
    }
}

