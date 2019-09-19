﻿using System.Collections.Generic;
namespace CRMercury.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }
        public ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}