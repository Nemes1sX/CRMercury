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
        Task<EmployeeViewModel> GetAllEmployees();
        Task<EmployeeListViewModel> GetAllEmployeesList();
        Task<bool> AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task GetEmployeeData(int id);
        Task DeleteEmployee(int id);
    }
}
