using CRMercury.App.Converters;
using CRMercury.App.Dto;
using CRMercury.App.Interfaces;
using CRMercury.App.ViewModels;
using CRMercury.Data.Interfaces;
using CRMercury.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CRMercury.App.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private EmployeeConverter _employeeConverter;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeConverter = new EmployeeConverter();
        }


        public async Task<EmployeeListViewModel> GetAllEmployees()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetListAsync();

            return _employeeConverter.ToEmployeeListViewModel(employees);
        }

        public async Task<EmployeeViewModel> GetEmployeeData(int id)
        {
            if (!await _employeeRepository.ExistsAsync(id))
            {
                return new EmployeeViewModel();
            }

            Employee employee = await _employeeRepository.GetAsync(id);

            return _employeeConverter.ToEmployeeViewModel(employee);
        }

        public async Task<bool> AddEmployee(EmployeeViewModel employee)
        {
            Employee employeeTemp = _employeeConverter.ToEmployee(employee.Employee);
            bool employeeValid = true;
            if (employeeValid)
            {
                await _employeeRepository.AddAsync(employeeTemp);
            }
            return employeeValid;
        }

        public async System.Threading.Tasks.Task DeleteEmployee(int id)
        {
            if (await _employeeRepository.ExistsAsync(id))
            {
                await _employeeRepository.DeleteAsync(id);
            }
        }

        public async System.Threading.Tasks.Task UpdateEmployee(int id, EmployeeViewModel employee)
        {
            Employee employeeTemp = _employeeConverter.ToEmployee(employee.Employee);
            if ((await _employeeRepository.ExistsAsync(id)))
            {
                employeeTemp.id = id;
                await _employeeRepository.UpdateAsync(employeeTemp);
            }
        }
    }
}
