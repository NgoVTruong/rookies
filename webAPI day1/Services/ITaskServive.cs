using webAPI_day1.Models;

namespace webAPI_day1.Services
{
    public interface ITaskService
    {
        List<MyTask> GetAll();
        MyTask? GetOne(int id);
        MyTask Add(MyTask task);
        MyTask? Edit(MyTask task);
        void Delete(int id);
    }
}