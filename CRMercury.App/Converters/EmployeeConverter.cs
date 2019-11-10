using System.Collections.Generic;
using System.Collections.ObjectModel;
using CRMercury.App.Dto;
using CRMercury.App.ViewModels;
using CRMercury.Data.Models;

namespace CRMercury.App.Converters
{
    public class EmployeeConverter : GenericConverter<Employee, EmployeeDto> 
     {
        public Employee ToEmployee(EmployeeDto employeeDto)
        {
            Employee employee = new Employee
            {
            fullname = employeeDto.fullname,
            password = employeeDto.password,
            email = employeeDto.email,
            status = employeeDto.status,
            };
            return employee;
        }
        public override EmployeeDto ToDto(Employee employee)
        {
            EmployeeDto employeeDto = new EmployeeDto
            {
                fullname = employee.fullname,
                password = employee.password,
                email = employee.email,
                status = employee.status,
            };
            return employeeDto;
        }
        public EmployeeListViewModel ToEmployeeListViewModel(IEnumerable<Employee> employees)
        {
            return new EmployeeListViewModel(ToDtoList(employees));
        }

        public EmployeeViewModel ToEmployeeViewModel(Employee employee)
        {
            return new EmployeeViewModel(ToDto(employee));
        }

    }
}