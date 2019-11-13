using CRMercury.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMercury.App.ViewModels 
{ 
    public class TaskListViewModel 
    {
        public IEnumerable<TaskDto> Tasks { get; set; }
        public TaskListViewModel() 
        { 

        }
        public TaskListViewModel(IEnumerable<TaskDto> tasksDto)
        {
            this.Tasks = tasksDto;
        }
    }
}
