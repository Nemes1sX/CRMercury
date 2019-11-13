using CRMercury.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMercury.App.ViewModels
{
	public class TaskViewModel
    {
		public TaskDto Task { get; set; }
		public TaskViewModel()
        {

        }
		public TaskViewModel(TaskDto taskDto)
        {
            this.Task = taskDto;
        }
    }
}
