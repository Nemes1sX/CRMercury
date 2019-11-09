using Microsoft.EntityFrameworkCore;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using CRMercury.Models;
using CRMercury.Interfaces;
  
namespace CRMercury.Models{
    public class CompanyDataAccessLayer : ICompany{
           
            private CRMercuryContext db;

        public CompanyDataAccessLayer(CRMercuryContext _db)
        {
            db = _db;
        }
        public IEnumerable<Company> GetAll()  
        {   
                return db.Companies.ToList();  
        }  
  
       public IEnumerable<Company> Sort(string sort){
              

            var Companies = from c in db.Companies
                           select c;
             switch(sort)
            {
                case "name":
                    Companies =   db.Companies.OrderByDescending(c => c.name);
                    break;
                case "ceoname":
                    Companies =   db.Companies.OrderBy(c => c.ceoname);
                    break;
                case "ceoname_desc":
                    Companies =     db.Companies.OrderByDescending(c => c.ceoname);
                    break;
                default:
                     Companies =  db.Companies.OrderBy(c => c.name);
                    break;      
            }       
            return Companies.ToList();
        } 
        public IEnumerable<Company> Search(string key){
        if (!String.IsNullOrEmpty(key)){
            return  db.Companies.Where(c => c.name.Contains(key)
                               || c.ceoname.Contains(key));
            } 
            return db.Companies.ToList();                  
        }

        //To Add new employee record   
        public int AddCompany(Company company)  
        {  
                db.Companies.Add(company);  
                db.SaveChanges();  
                return 1;   
        }  
  
        //To Update the records of a particluar employee  
        public int UpdateCompany(Company company)  
        {  
                db.Entry(company).State = EntityState.Modified;  
                db.SaveChanges();  
                return 1;   
        }  
         public Company FindCompany(int id)  
        {    
                Company company = db.Companies.Find(id);  
                return company;   
        }  
  
        //To Delete the record of a particular employee  
        public int DeleteCompany(int id)  
        {  
                Company company = db.Companies.Find(id);  
                db.Companies.Remove(company);  
                db.SaveChanges();  
                return 1;   

        }
    }
}        
