using CRMercury.Data.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CRMercury.Data.Models
{


    public class Company : IEntity
    {
        public int id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Company name length can't be more than 50.")]
        public string name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "CEO Name length can't be more than 50.")]
        public string ceoname { get; set; }
        [Required]
        public string website { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public bool status { get; set; }

        public ICollection<DailyTask> DailyTasks { get; set; }


    }

}