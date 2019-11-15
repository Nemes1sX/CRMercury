using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using CRMercury.Data.Repositories;
using CRMercury.Data.Interfaces;
using CRMercury.App.Interfaces;
using CRMercury.App.Services;






namespace CRMercury.Ioc
{
    public class DependecyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<ICompanyService, CompanyService>();
            service.AddScoped<ICompanyRepository, CompanyRepository>();   

            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();

            service.AddScoped<ITaskService, TaskService>();
            service.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}