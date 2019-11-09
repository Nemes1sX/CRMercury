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
            return db.Employees.ToList();  
        }

        //To Add new employee record 
        public int AddEmployee(Employee employee)
        {
                db.Employees.Add(employee);
                db.SaveChanges();
                return 1;
        }

        //To Update the records of a particluar employee
        public int UpdateEmployee(Employee employee)
        {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
        }

        //Get the details of a particular employee
        public Employee GetEmployeeData(int id)
        {
                Employee employee = db.Employees.Find(id);
                return employee;
        }

        //To Delete the record on a particular employee
        public int DeleteEmployee(int id)
        {
                Employee emp = db.Employees.Find(id);
                db.Employees.Remove(emp);
                db.SaveChanges();
                return 1;
        }

    }
}
