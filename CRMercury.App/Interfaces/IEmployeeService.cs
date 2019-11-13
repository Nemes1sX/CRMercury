using CRMercury.Data.Models;
using CRMercury.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CRMercury.Interfaces
{
    public interface IEmployee
    {
        Task<EmployeeListViewModel> GetAllEmployees();
        Task<bool> AddEmployee(EmployeeViewModel employee);
        Task UpdateEmployee(EmployeeViewModel employee, int id);
        Task<EmployeeViewModel> GetEmployeeData(int id);
        Task DeleteEmployee(int id);
    }
}
