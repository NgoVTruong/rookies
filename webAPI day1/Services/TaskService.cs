using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_day1.Models;
using webAPI_day1.Services;

namespace webAPI_day1.Services
{
    public class TaskService : ITaskService
    {
        private static List<MyTask> _taskList = new List<MyTask>(){
        new MyTask{
            Id = 0,
            Title = "My task 1",
            IsCompleted = true
        },
        new MyTask{
            Id = 1,
            Title = "My task 2",
            IsCompleted = true
        },
        new MyTask{
            Id = 2,
            Title = "My task 3",
            IsCompleted = false
        }
    };

        public List<MyTask> GetAll()
        {
            return _taskList;
        }

        public MyTask? GetOne(int id)
        {
            return _taskList.FirstOrDefault(task => task.Id == id);
        }

        public MyTask Add(MyTask task)
        {
            _taskList.Add(task);
            return task;
        }


        public void Delete(int id)
        {
            var result = _taskList.FirstOrDefault(taskDelete => taskDelete.Id == id);

            if (result != null)
            {
                _taskList.Remove(result);
            }
        }


        public MyTask? Edit(MyTask task)
        {
            var result = _taskList.FirstOrDefault(task => task.Id == task.Id);

            if (result != null)
            {
                result.Title = task.Title;
                result.IsCompleted = task.IsCompleted;

                return result;
            }
            return null;
        }
    }
}