using CRMercury.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMercury.App.ViewModels 
{ 
    public class DailyTaskListViewModel 
    {
        public IEnumerable<DailyTaskDto> DailyTasks { get; set; }
        public DailyTaskListViewModel() 
        { 

        }
        public DailyTaskListViewModel(IEnumerable<DailyTaskDto> dailytasksDto)
        {
            this.DailyTasks = dailytasksDto;
        }
    }
}
