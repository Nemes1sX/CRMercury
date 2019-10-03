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
            try  
            {  
                return db.Companies.ToList();  
            }  
            catch  
            {  
                throw;  
            }  
        }  
  
        //To Add new employee record   
        public int AddCompany(Company company)  
        {  
            try  
            {  
                db.Companies.Add(company);  
                db.SaveChanges();  
                return 1;  
            }  
            catch  
            {  
                throw;  
            }  
        }  
  
        //To Update the records of a particluar employee  
        public int UpdateCompany(Company company)  
        {  
            try  
            {  
                db.Entry(company).State = EntityState.Modified;  
                db.SaveChanges();  
  
                return 1;  
            }  
            catch  
            {  
                throw;  
            }  
        }  
         public Company FindCompany(int id)  
        {  
            try  
            {  
                Company company = db.Companies.Find(id);  
                return company;  
            }  
            catch  
            {  
                throw;  
            }  
        }  
  
        //To Delete the record of a particular employee  
        public int DeleteCompany(int id)  
        {  
            try  
            {  
                Company company = db.Companies.Find(id);  
                db.Companies.Remove(company);  
                db.SaveChanges();  
                return 1;  
            }  
            catch  
            {  
                throw;  
            }  

        }
    }
}        
