using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using CRMercury.Models;


 namespace CRMercury.Models {
  public class CRMercuryContext : DbContext{
         public CRMercuryContext(DbContextOptions<CRMercuryContext> options)
            : base(options)
        { }
         public DbSet<Company> Companies { get; set; }
         public DbSet<Employee> Employees {get; set;}
         public DbSet<Task> Tasks {get; set;}

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Task>().ToTable("Task");
            Relations(modelBuilder);
        }
        private void Relations(ModelBuilder modelBuilder){
            modelBuilder.Entity<Employee>()
            .HasMany(c => c.Tasks)
            .WithOne(e => e.Employee)
           .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Company>()
            .HasMany(c => c.Tasks)
            .WithOne(e => e.Company)
            .OnDelete(DeleteBehavior.Cascade);
        }
     }

 }     