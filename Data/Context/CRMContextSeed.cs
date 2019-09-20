//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using CRMercury.Data.Models;

//namespace CRMercury.Data.Context
//{
//    public class CRMContextSeed
//    {
//        public static void Initialize(CRMContext context)
//        {
//            context.Database.EnsureCreated();

//            if (DbEmpty(context))
//            {
//                SeedDb(context);
//            }
//        }
//        private static bool DbEmpty(CRMContext context)
//        {
//            return !context.Roles.Any()
//                && !context.Permissions.Any()
//                && !context.RolePermissions.Any();
//        }
//        private static void SeedDb(CRMContext context)
//        {
//            AddCompanies(context);
//            AddDailyTasks(context);
//            AddEmployees(context);
//            AddEmployeeDailyTasks(context);
//        }
//        private static void AddCompanies(CRMContext context)
//        {
//            var companies = new Company[]{
//                new Company{ Name="MicroSoft"},
//                new Company{ Name="IBM"}};

//            context.Companies.AddRange(companies);
//            context.SaveChanges();
//        }
//        private static void AddDailyTasks(CRMContext context)
//        {
//            var dailyTasks = new DailyTask[]{
//                new DailyTask{ Title="Programming", Description="Programming all day and night"},
//                new DailyTask{ Title="Testing", Description="Testing and debugging software"},
//                new DailyTask{ Title="DB managing", Description="Managing sql data bases"}};

//            context.DailyTasks.AddRange(dailyTasks);
//            context.SaveChanges();
//        }
//        private static void AddEmployees(CRMContext context)
//        {
//            var employees = new Employee[]{
//                new Employee{FirstName="Jonukas",LastName="Tuktuk",Company = context.Companies.FirstOrDefault(s => s.CompanyId == 1)},
//                new Employee{FirstName="Onute",LastName="Tiktik",Company = context.Companies.FirstOrDefault(s => s.CompanyId == 1)},
//                new Employee{FirstName="Petriukas",LastName="Lalala"},
//                new Employee{FirstName="Aldona",LastName="Tatata",Company = context.Companies.FirstOrDefault(s => s.CompanyId == 2)}};

//            context.Employees.AddRange(employees);
//            context.SaveChanges();
//        }
//        private static void AddEmployeeDailyTasks(CRMContext context)
//        {
//            var employeeTasks = new EmployeeDailyTask[]{
//                new EmployeeDailyTask{ EmployeeId=1, DailyTaskId=1 },
//                new EmployeeDailyTask{ EmployeeId=1, DailyTaskId=2 },
//                new EmployeeDailyTask{ EmployeeId=2, DailyTaskId=2 },
//                new EmployeeDailyTask{ EmployeeId=4, DailyTaskId=2 },
//                new EmployeeDailyTask{ EmployeeId=4, DailyTaskId=3 }};

//            context.EmployeeDailyTasks.AddRange(employeeTasks);
//            context.SaveChanges();
//        }
//    }
//}
