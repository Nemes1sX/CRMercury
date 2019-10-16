using CRMercury.Interfaces;
using CRMercury.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMercury.Models {
    public class TasksDataAccessLayer : ITask {

        private CRMercuryContext db;

          public TasksDataAccessLayer(CRMercuryContext _db)
        {
            db = _db;
        }
           
             public IEnumerable<Task> GetAll()
        {
            try
            {
                return db.Tasks.ToList();
            }
            catch
            {
                throw;
            }
        }
            public int AddTask(Task task)
            {
                try
                {
                    db.Tasks.Add(task);
                    db.SaveChanges(); 
                    return 1;
                }
                catch
                {
                   throw;      
                }
            }

        public Task FindTask(int id){
            try
            {
                Task task = db.Tasks.Find(id);
                return task;
            }
            catch
            {
                throw;
            }
        }

            public int UpdateTask(Task task)
            {
                try
                {
                    db.Entry(task).State = EntityState.Modified;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                  throw;  
                }
            }
            public int DeleteTask(int id){
                try
                {
                    Task tsk = db.Tasks.Find(id);
                    db.Tasks.Remove(tsk);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    throw;
                }
            }
    }
}