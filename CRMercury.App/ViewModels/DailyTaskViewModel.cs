using CRMercury.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMercury.App.ViewModels
{
	public class DailyTaskViewModel
    {
		public DailyTaskDto DailyTask { get; set; }
		public DailyTaskViewModel()
        {

        }
		public DailyTaskViewModel(DailyTaskDto dailytaskDto)
        {
            this.DailyTask = dailytaskDto;
        }
    }
}
