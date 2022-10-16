using Microsoft.AspNetCore.Mvc;

namespace New_folder.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/new")]
        public int CreateANewTask([FromBody] NewTaskRequestModel requestModel)
        {
            var newID = 1;
            return newID;
        }
    }
}