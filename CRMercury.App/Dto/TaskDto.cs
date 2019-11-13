using System;

namespace CRMercury.App.Dto
{

    public class TaskDto
    {
        public int id { get; set; }

        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }

        public string name { get; set; }

        public DateTime taskdate { get; set; }
 
        public string description { get; set; }
       
        public State state { get; set; }
        
        public bool status { get; set; }
    }

}