using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;





namespace SimpleCRM.Ioc
{
    public class DependecyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<ICompanyService, CompanyService>();
            service.AddScoped<ICompanyRepository, CompanyRepository>();   

            service.AddScoped<IEmpoyeeService, EmployeeService>();
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();

            service.AddScoped<ITaskService, TaskService>();
            service.AddScoped<ITaskRespitory, TaskRespitory>();
        }
    }
}