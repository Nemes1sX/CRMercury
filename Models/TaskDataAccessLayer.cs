using CRMercury.Interfaces;
using CRMercury.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMercury.Models 
{
    public class TasksDataAccessLayer : ITask {

        private CRMercuryContext db;

        public TasksDataAccessLayer(CRMercuryContext _db)
        {
            db = _db;
        }
           
        public IEnumerable<Task> GetAll()
            {
                return db.Tasks.Include(e => e.Employee).Include(c => c.Company).ToList();
            }
        public int AddTask(Task task)
            {          
                db.Tasks.Add(task);
                db.SaveChanges(); 
                return 1;
            }

        public Task FindTask(int id)
            {
                Task task = db.Tasks.Include(e => e.Employee)
                .Include(c => c.Company)
                .SingleOrDefault(x => x.id == id);
                return task;
            }

        public int UpdateTask(Task task)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            public int DeleteTask(int id)
                {          
                    Task task = db.Tasks.Find(id);
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                    return 1;
                }         
    }
}