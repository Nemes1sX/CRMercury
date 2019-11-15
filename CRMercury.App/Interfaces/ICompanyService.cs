using CRMercury.Data.Models;
using CRMercury.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMercury.App.Services
{
	public interface ICompanyService
    {
        Task<CompanyListViewModel> GetAllCompanies();
        Task<bool> AddCompany(CompanyViewModel company);
        System.Threading.Tasks.Task UpdateCompany(int id, CompanyViewModel company);
        Task<CompanyViewModel> FindCompany(int id);
        System.Threading.Tasks.Task DeleteCompany(int id);
        Task<CompanyListViewModel> CompanySort(string sort);
        Task<CompanyListViewModel> CompanySearch(string key);
    }
}

