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
                id = companyDto.Id,
                name = companyDto.Name,
                ceoname = companyDto.Ceoname,
                website = companyDto.Website,
                email = companyDto.Email,
                phone = companyDto.Phone,
                status = companyDto.Status,
            };
            return company;
        }

        public override CompanyDto ToDto(Company company)
        {
            CompanyDto companyDto = new CompanyDto
            {
                Id = company.id,
                Name = company.name,
                Ceoname = company.ceoname,
                Website = company.website,
                Email = company.email,
                Phone = company.phone,
                Status = company.status,
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