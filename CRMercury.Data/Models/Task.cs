using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using CRMercury.Data.Models;
using CRMercury.Data.Interfaces;


namespace CRMercury.Data.Models {

public enum State : int{
    Started, Planned, Executed, Delayed, Completed
}

public class Task : IEntity{
    
    public int id {get; set;}

    public int CompanyId {get; set;}
    public int EmployeeId {get; set;}

    [Required]
    public string name {get; set;}

    [Required]
    public DateTime taskdate {get; set;}
    [Required]
    [StringLength(1000, ErrorMessage = "Task description length can't be more than 1000.")]
    public string description {get; set;}
    [Required]
    public State state {get; set;}
    [Required]
    public bool status {get; set;}


    public Company Company {get; set;}
    public Employee Employee {get; set;}

}

}    