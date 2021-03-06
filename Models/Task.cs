using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using CRMercury.Models;



namespace CRMercury.Models {

public enum State : int{
    Started, Planned, Executed, Delayed, Completed
}

public class Task{
    
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