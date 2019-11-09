using CRMercury.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CRMercury.Interfaces {
    public interface ITask {
    IEnumerable<Task> GetAll();

    int AddTask(Task task);

    Task FindTask(int id);

    int UpdateTask(Task task);

    int DeleteTask(int id);


    }
}