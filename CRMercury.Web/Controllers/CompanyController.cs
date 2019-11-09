using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;   
using CRMercury.Models;
using CRMercury.Interfaces;

namespace CRMercury.Controllers{
    [ApiController]
    [Route("api/[controller]")] 
    public class CompanyController : ControllerBase {

          private readonly ICompany obj;

        public CompanyController(ICompany _obj)
        {
            obj = _obj;
        }
      

        [HttpGet]  
        [Route("Index")]  
        public IEnumerable<Company> Index()  
        {  
            return obj.GetAll();  
        }  
  
        [HttpPost]  
        [Route("Create")]  
        public int Create([FromBody] Company company)  
        {  
            return obj.AddCompany(company);  
        }  

        [HttpGet]  
        [Route("Details/{id}")]  
        public Company Details(int id)  
        {  
            return obj.FindCompany(id);  
        }  
  
        [HttpPut]  
        [Route("Edit")]  
        public int Edit([FromBody]Company company)  
        {  
            return obj.UpdateCompany(company);  
        }  
  
        [HttpDelete]  
        [Route("Delete/{id}")]  
        public int Delete(int id)  
        {  
            return obj.DeleteCompany(id);  
        }
        [HttpGet]
        [Route("Index/Sort/{sort}")]
        public IEnumerable<Company> Sort(string sort){
            return obj.Sort(sort);
        }
        [HttpGet]
        [Route("Index/Search/{key}")]
        public IEnumerable<Company> Search(string key){
            return obj.Search(key);
        }
    }
}