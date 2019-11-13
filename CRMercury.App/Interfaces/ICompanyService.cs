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
        Task<CompanyListViewModel> GetAllCompanies();
        Task<bool> AddCompany(CompanyViewModel company);
        Task UpdateCompany(CompanyViewModel company, int id);
        Task<CompanyViewModel> FindCompany(int id);
        Task DeleteCompany(int id);
        Task<CompanyListViewModel> CompanySort(string sort);
        Task<CompanyListViewModel> CompanySearch(string key);
    }
}

