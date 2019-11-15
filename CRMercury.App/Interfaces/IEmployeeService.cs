using CRMercury.Data.Models;
using CRMercury.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CRMercury.App.Interfaces
{
    public interface IEmployeeService
    {
        System.Threading.Tasks.Task<EmployeeListViewModel> GetAllEmployees();
        System.Threading.Tasks.Task<bool> AddEmployee(EmployeeViewModel employee);
        System.Threading.Tasks.Task UpdateEmployee(int id, EmployeeViewModel employee);
        Task<EmployeeViewModel> GetEmployeeData(int id);
        System.Threading.Tasks.Task DeleteEmployee(int id);
    }
}
