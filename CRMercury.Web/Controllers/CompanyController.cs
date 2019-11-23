using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;   
using CRMercury.App.Interfaces;
using CRMercury.App.ViewModels;
using CRMercury.App.Converters;
using CRMercury.App.Services;
using Microsoft.AspNetCore.Http;

namespace CRMercury.Web.Controllers{
    [Route("api/[controller]")] 
    [ApiController]
    public class CompanyController : ControllerBase {

          private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
      

        [HttpGet]  
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("Index")]  
        public async Task<IActionResult> Index()  
        {  
            return Ok(await _companyService.GetAllCompanies());
        }  
  
        [HttpPost]  
        [Route("Create")]  
        public async Task<IActionResult> Create(CompanyViewModel company)  
        {  
            bool success = await _companyService.AddCompany(company);
            if(success)
                return Ok();
            else
                return BadRequest();
        }  

        [HttpGet]  
        [Route("Details/{id}")]  
        public async Task<IActionResult> Details(int id)  
        {  
            var company = await _companyService.FindCompany(id);

            if(company.Company != null)
                return Ok(company);
            else
                return BadRequest();
        }  
  
        [HttpPut]  
        [Route("Edit")]  
        public async Task<IActionResult> Edit(int id, CompanyViewModel company)  
        {  
            await _companyService.UpdateCompany(id, company);

            return NoContent();

        }  
        [HttpDelete]  
        [Route("Delete/{id}")]  
        public async Task<IActionResult> Delete(int id)  
        {  
            await _companyService.DeleteCompany(id);

            return NoContent();
        }
        [HttpGet]
        [Route("Index/Sort/{sort}")]
        public async Task<IActionResult> Sort(string sort){
            return Ok(await _companyService.CompanySort(sort));


        }
        [HttpGet]
        [Route("Index/Search/{key}")]
        public async Task<IActionResult> Search(string key){

            return Ok(await _companyService.CompanySearch(key));

             

        }
    }
}