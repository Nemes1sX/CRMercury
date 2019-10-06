using CRMercury.Interfaces;
using CRMercury.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMercury.Models
{
    public class EmployeeDataAccessLayer : IEmployee
    {
        private CRMercuryContext db;

        public EmployeeDataAccessLayer(CRMercuryContext _db)
        {
            db = _db;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return db.Employees.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record 
        public int AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee
        public int UpdateEmployee(Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee
        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee employee = db.Employees.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record on a particular employee
        public int DeleteEmployee(int id)
        {
            try
            {
                Employee emp = db.Employees.Find(id);
                db.Employees.Remove(emp);
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
