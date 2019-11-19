using CRMercury.Data.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CRMercury.Data.Models
{

    public enum Role : int
    {
        Admin, Ceo, Employee
    }

    public class Employee : IEntity
    {

        public int id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$")]
        public string fullname { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password length must be between 8 and 30.")]
        public string password { get; set; }
        [Required]
        public bool status { get; set; }

        //public Role role {get; set;}

        public ICollection<DailyTask> Tasks { get; set; }


    }

}