using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRMercury.Data.Context;
using CRMercury.Data.Models;


namespace CRMercury.Data.Context
{
    public class CRMercuryContextSeed
    {
        public static void Initialize(CRMercuryContext context)
        {
            context.Database.EnsureCreated();
			AddEmployees(context);
        }
        private static void AddEmployees(CRMercuryContext context)
        {
            var employees = new Employee[]{
                new Employee{fullname = "Programmer", password = "lala@gmail.com", email = "vardenis@gmail.com", status = true},
                new Employee{fullname = "Programmer", password = "lala@gmail.com", email = "vardenis@gmail.com", status = true},

            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}