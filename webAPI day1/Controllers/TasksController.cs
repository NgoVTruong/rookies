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

    [HttpPost("/v1/bulk")]
    private IActionResult CreateBulkTask_V1([FromBody] List<NewTaskRequestModel> requestModels)
    {
        try
        {
            _ = CreateMutilTask_V1(requestModels);
            return Accept();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error creating");
        }
    }

    private Task CreateMutilTask_V1(List<NewTaskRequestModel> requestModels)
    {
        foreach (var requestModel in requestModels)
        {
         x   CreateANewTask__Service_v1(requestModel);
        }
        return Task.CompletedTask;
    }
    private void CreateANewTask__Service_V1(NewTaskRequestModel requestModel)
    {
        System.Threading.Thread.Sleep(10);
    }
    private Task SendEmail_V1()
    {
        return Task.CompletedTask;
    }
}