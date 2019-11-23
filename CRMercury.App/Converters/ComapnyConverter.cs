using System.Collections.Generic;
using System.Collections.ObjectModel;
using CRMercury.App.Dto;
using CRMercury.App.ViewModels;
using CRMercury.Data.Models;
using CRMercury.App.Converters;

namespace CRMerucry.App.Converters
{
    public class CompanyConverter : GenericConverter<Company, CompanyDto>
    {
        public Company ToCompany(CompanyDto companyDto)
        {
            Company company = new Company
            {
                id = companyDto.id,
                name = companyDto.name,
                ceoname = companyDto.ceoname,
                website = companyDto.website,
                email = companyDto.email,
                phone = companyDto.phone,
                status = companyDto.status,
            };
            return company;
        }

        public override CompanyDto ToDto(Company company)
        {
            CompanyDto companyDto = new CompanyDto
            {
                id = company.id,
                name = company.name,
                ceoname = company.ceoname,
                website = company.website,
                email = company.email,
                phone = company.phone,
                status = company.status,
            };
            return companyDto;
        }

        public CompanyListViewModel ToCompanyListViewModel(IEnumerable<Company> companies)
        {
            return new CompanyListViewModel(ToDtoList(companies));
        }

        public CompanyViewModel ToCompanyViewModel(Company company)
        {
            return new CompanyViewModel(ToDto(company));
        }



    }
}