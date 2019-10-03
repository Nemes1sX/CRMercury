using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRMercury.Models;

namespace CRMercury.Models
{
    public class CRMercuryContextSeed
    {
        public static void Initialize(CRMercuryContext context)
        {
            context.Database.EnsureCreated();
			AddCompanies(context);
        }
        private static void AddCompanies(CRMercuryContext context)
        {
            var roles = new Company[]{
                new Company{name = "Programmer", ceoname = "lala", website = "vardenis.lt", phone = "656", email = "vardenis@gmail.com", status = true},
                new Company{name = "Programmer", ceoname = "lala", website = "vardenis.lt", phone = "656", email = "vardenis@gmail.com", status = true},
            };

            context.Companies.AddRange(roles);
            context.SaveChanges();
        }
    }
}