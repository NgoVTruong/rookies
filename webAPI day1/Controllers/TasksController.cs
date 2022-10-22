using Microsoft.AspNetCore.Mvc;
using webAPI_day1.models;

namespace webAPI_day1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        [HttpGet(Name = "GetTasks")]
        public IActionResult GetTasks()
        {
            List<MyTask> myTasks = new List<MyTask>();
            myTasks.Add(new MyTask() { Id = 1, Title = "Some title 1", IsCompleted = false });
            myTasks.Add(new MyTask() { Id = 2, Title = "Some title 2", IsCompleted = false });

            return new JsonResult(myTasks);
        }
    }
}