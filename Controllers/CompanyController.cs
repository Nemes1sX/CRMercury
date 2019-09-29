using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;   
using CRMercury.Models;
using CRMercury.Interfaces;

namespace CRMercury.Controllers{
    public class CompanyController : Controller {

          private readonly ICompany obj;

        public CompanyController(ICompany _obj)
        {
            obj = _obj;
        }
      

        [HttpGet]  
        [Route("api/Company/Index")]  
        public IEnumerable<Company> Index()  
        {  
            return obj.GetAll();  
        }  
  
        [HttpPost]  
        [Route("api/Company/Create")]  
        public int Create([FromBody] Company company)  
        {  
            return obj.AddCompany(company);  
        }  

        [HttpGet]  
        [Route("api/Company/Details/{id}")]  
        public Company Details(int id)  
        {  
            return obj.FindCompany(id);  
        }  
  
        [HttpPut]  
        [Route("api/Employee/Edit")]  
        public int Edit([FromBody]Company company)  
        {  
            return obj.UpdateCompany(company);  
        }  
  
        [HttpDelete]  
        [Route("api/Company/Delete/{id}")]  
        public int Delete(int id)  
        {  
            return obj.DeleteCompany(id);  
        }  
    }
}