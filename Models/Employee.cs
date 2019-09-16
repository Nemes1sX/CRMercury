using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
     public class EmployeeContext : DbContext{
         public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        { }
         public DbSet<Employee> Employees { get; set; }
     }

public class Employee
    {
    public int id { get; set; }
    
    public string fullname {get; set;}

    public string email {get; set;}

    public string password {get; set; } 
    }

}
