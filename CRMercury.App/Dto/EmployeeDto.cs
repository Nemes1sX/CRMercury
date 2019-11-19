using System;

namespace CRMercury.App.Dto
{
    public class EmployeeDto
    {
        public int id { get; set; }
        public string fullname { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
    }
}