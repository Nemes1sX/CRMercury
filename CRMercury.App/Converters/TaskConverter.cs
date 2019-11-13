using System.Collections.Generic;
using System.Collections.ObjectModel;
using CRMercury.App.Dto;
using CRMercury.App.ViewModels;
using CRMercury.Data.Models;

namespace SimpleCRM.App.Converters
{
    public class EmployeeConverter : GenericConverter<Employee, EmployeeDto>
    {
        public Task ToTask(TaskDto taskDto)
        {
            Task task = new task
            {
                name = taskDto.name,
                state = taskDto.state,
                status = taskDto.status,
                taskdate = taskDto.taskdate,
                description = taskDto.description,
            };
            return task;
        }

        public override taskDto ToDto(Task task)
        {
            TaskDto taskDto = new taskDto
            {
                id = task.id,
                name = task.name,
                state = task.state,
                status = task.status,
                taskdate = task.taskdate,
                description = task.description,
  
                EmployeeId = task.employee.id,
                CompanyId = task.company.id,
            };
            return taskDto;
        }

        public TaskListViewModel ToTaskListViewModel(IEnumerable<Task> tasks)
        {
            return new TaskListViewModel(ToDtoList(tasks));
        }

        public TaskViewModel ToTaskViewModel(Task task)
        {
            return new TaskViewModel(ToDto(task));
        }

    }
}