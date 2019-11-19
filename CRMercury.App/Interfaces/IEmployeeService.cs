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
        Task<EmployeeListViewModel> GetAllEmployees();
        Task<bool> AddEmployee(EmployeeViewModel employee);
        Task UpdateEmployee(int id, EmployeeViewModel employee);
        Task<EmployeeViewModel> GetEmployeeData(int id);
        Task DeleteEmployee(int id);
    }
}
