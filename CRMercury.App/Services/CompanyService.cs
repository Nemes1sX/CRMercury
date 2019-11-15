using CRMercury.App.Interfaces;
using CRMercury.App.ViewModels;
using CRMercury.Data.Interfaces;
using CRMercury.Data.Models;
using CRMerucry.App.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMercury.App.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;
        private CompanyConverter _companyConverter;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            _companyConverter = new CompanyConverter();
        }

        public async System.Threading.Tasks.Task<bool> AddCompany(CompanyViewModel company)
        {
            // TODO validation
            Company companyTemp = _companyConverter.ToCompany(company.Company);
            bool companyValid = true; // TODO validation
            if (companyValid)
            {
                await _companyRepository.AddAsync(companyTemp);
            }
            return companyValid;
        }

        public async System.Threading.Tasks.Task DeleteCompany(int id)
        {
            if (await _companyRepository.ExistsAsync(id))
            {
                await _companyRepository.DeleteAsync(id);
            }
        }

        public async System.Threading.Tasks.Task<CompanyViewModel> FindCompany(int id)
        {
            if (!await _companyRepository.ExistsAsync(id))
            {
                return new CompanyViewModel();
            }

            Company company = await _companyRepository.GetAsync(id);

            return _companyConverter.ToCompanyViewModel(company);
        }

        public async System.Threading.Tasks.Task<CompanyListViewModel> GetAllCompanies()
        {
            IEnumerable<Company> companies = await _companyRepository.GetListAsync();

            return _companyConverter.ToCompanyListViewModel(companies);
        }

        public async System.Threading.Tasks.Task<CompanyListViewModel> CompanySearch(string search)
        {
            // TODO validation
            IEnumerable<Company> companies = await _companyRepository.GetListAsyncSearch(search);

            return _companyConverter.ToCompanyListViewModel(companies);
        }

        public async System.Threading.Tasks.Task<CompanyListViewModel> CompanySort(string sort)
        {
            // TODO validation
            IEnumerable<Company> companies = await _companyRepository.GetListAsyncSort(sort);

            return _companyConverter.ToCompanyListViewModel(companies);
        }

        public async System.Threading.Tasks.Task UpdateCompany(int id, CompanyViewModel company)
        {
            // TODO validation
            Company companyTemp = _companyConverter.ToCompany(company.Company);
            if (await _companyRepository.ExistsAsync(id))
            {
                companyTemp.id = id;
                await _companyRepository.UpdateAsync(companyTemp);
            }
        }
    }
}