using System.Collections.Generic;
using System.Collections.ObjectModel;
using CRMercury.App.Dto;
using CRMercury.App.ViewModels;
using CRMercury.Data.Models;

namespace CRMercury.App.Converters
{
    public class DailyTaskConverter : GenericConverter<DailyTask, DailyTaskDto>
    {
        public DailyTask ToDailyTask(DailyTaskDto dailytaskDto)
        {
            DailyTask dailytask = new DailyTask
            {
                name = dailytaskDto.name,
                state =  (State) dailytaskDto.state,
                status = dailytaskDto.status,
                taskdate = dailytaskDto.taskdate,
                description = dailytaskDto.description,

                EmployeeId = dailytaskDto.EmployeeId,
                CompanyId = dailytaskDto.CompanyId,
            };
            return dailytask;
        }

        public override DailyTaskDto ToDto(DailyTask dailytask)
        {
            DailyTaskDto dailytaskDto = new DailyTaskDto
            {
                id = dailytask.id,
                name = dailytask.name,
                state = (int) dailytask.state,
                status = dailytask.status,
                taskdate = dailytask.taskdate,
                description = dailytask.description,
  
                EmployeeId = dailytask.Employee.id,
                CompanyId = dailytask.Company.id,
            };
            return dailytaskDto;
        }

        public DailyTaskListViewModel ToDailyTaskListViewModel(IEnumerable<DailyTask> tasks)
        {
            return new DailyTaskListViewModel(ToDtoList(tasks));
        }

        public DailyTaskViewModel ToDailyTaskViewModel(DailyTask task)
        {
            return new DailyTaskViewModel(ToDto(task));
        }

    }
}