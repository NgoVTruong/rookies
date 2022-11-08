using Microsoft.AspNetCore.Mvc;
using webAPI_day1.Services;
using webAPI_day1.Models;


namespace webAPI_day1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService service)
        {
            _taskService = service;
        }

        [HttpGet("")]
        public ActionResult<List<MyTask>> GetAll()
        {
            try
            {
                var model = _taskService.GetAll();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MyTask> GetOne(int id)
        {
            try
            {
                var model = _taskService.GetOne(id);

                if (model != null)
                {
                    return Ok(model);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult<MyTask> Add([FromBody] MyTask model)
        {
            if (model != null)
            {
                try
                {
                    var task = new MyTask
                    {
                        Id = model.Id,
                        Title = model.Title,
                        IsCompleted = model.IsCompleted
                    };

                    return _taskService.Add(task);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex);
                }
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, MyTask model)
        {
            var task = _taskService.GetOne(id);

            if (task != null)
            {
                try
                {
                    task.Title = model.Title;
                    task.IsCompleted = model.IsCompleted;

                    var result = _taskService.Edit(task);
                    return new JsonResult(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex);
                }
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = _taskService.GetOne(id);

            if (task != null)
            {
                try
                {
                    _taskService.Delete(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex);
                }
            }

            return NotFound();
        }

    }


}