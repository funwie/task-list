using Imparta.Application.Task;
using Imparta.Domain.Task;
using Imparta.Web.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imparta.Web.Controllers
{

    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskModel>> Get()
        {
            return await _taskService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (id == null || id == Guid.Empty) return new NotFoundObjectResult("Not Found");

            var task = await _taskService.GetByIdAync(id);

            if (task == null) return new NotFoundObjectResult("Not Found");

            return new JsonResult(task);
        }

        [HttpPost]
        public async Task<ActionResult> Post(TaskRequest taskRequest)
        {
            if (taskRequest == null) return new NotFoundObjectResult("Not Found");

            var task = await _taskService.AddAsync(taskRequest.MapToTask("d9d3e524-c901-480b-86a9-b77dd44c7198"));

            return new JsonResult(task);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(Guid id, [FromBody] TaskRequest taskRequest)
        {
            //if (taskRequest == null) return new NotFoundObjectResult("Not Found");

            ////var mappedTask = taskRequest.MapToTask("d9d3e524-c901-480b-86a9-b77dd44c7198")

            //var task = await _taskService.UpdateAsync(taskRequest);

            //return new JsonResult(task);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _taskService.RemoveAsync(id);
        }

        [HttpPatch("start/{id}")]
        public async Task<IActionResult> StartAsync(Guid id)
        {
            if (id == null || id == Guid.Empty) return new NotFoundObjectResult("Not Found");

            var task = await _taskService.GetByIdAync(id);

            if (task == null) return new NotFoundObjectResult("Not Found");

            var completedTask = await _taskService.StartAsync(task);

            return new JsonResult(completedTask);
        }

        [HttpPatch("complete/{id}")]
        public async Task<IActionResult> CompleteAsync(Guid id)
        {
            if (id == null || id == Guid.Empty) return new NotFoundObjectResult("Not Found");

            var task = await _taskService.GetByIdAync(id);

            if (task == null) return new NotFoundObjectResult("Not Found");

            var completedTask = await _taskService.CompleteAsync(task);

            return new JsonResult(completedTask);
        }

        [HttpPatch("open/{id}")]
        public async Task<IActionResult> OpenAsync(Guid id)
        {
            if (id == null || id == Guid.Empty) return new NotFoundObjectResult("Not Found");

            var task = await _taskService.GetByIdAync(id);

            if (task == null) return new NotFoundObjectResult("Not Found");

            var openTask = await _taskService.OpenAsync(task);

            return new JsonResult(openTask);
        }

    }
}
