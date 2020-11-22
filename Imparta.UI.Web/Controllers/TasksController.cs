using Imparta.Application.Task;
using Imparta.Domain.Task;
using Imparta.UI.Web.Responses;
using Imparta.Web.Requests;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskListService _taskListService;

        public TasksController(ITaskService taskService, ITaskListService taskListService)
        {
            _taskService = taskService;
            _taskListService = taskListService;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskModel>> GetAllAsync()
        {
            return await _taskService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleAsync(Guid id)
        {
            if (id == null || id == Guid.Empty) return new BadRequestResult();

            var task = await _taskService.GetByIdAync(id);

            if (task == null) return new NotFoundObjectResult($" {id} Not Found");

            var responseTask = GetTaskResponse(task);

            return new JsonResult(responseTask);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(TaskRequest taskRequest)
        {
            if (taskRequest == null) return new BadRequestResult();

            var taskList = await _taskListService.GetByIdAync(taskRequest.TaskListId);

            if (taskList == null) return new BadRequestResult();

            var mappedTask = taskRequest.MapToTaskModel(taskList);

            var task = await _taskService.AddAsync(mappedTask);

            var responseTask = GetTaskResponse(task);

            return new JsonResult(responseTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromBody] TaskRequest taskRequest)
        {
            if (id == null || id == Guid.Empty) return new BadRequestResult();

            if (taskRequest == null) return new BadRequestResult();

            var foundTask = await _taskService.GetByIdAync(id);

            if (foundTask == null) return new NotFoundObjectResult($" {id} Not Found");

            foundTask.Description = taskRequest.Description;

            var task = await _taskService.UpdateAsync(foundTask);

            var responseTask = GetTaskResponse(task);

            return new JsonResult(responseTask);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _taskService.RemoveAsync(id);
        }

        [HttpPatch("{id}/start")]
        public async Task<IActionResult> StartAsync(Guid id)
        {
            if (id == null || id == Guid.Empty) return new BadRequestResult();

            var task = await _taskService.GetByIdAync(id);

            if (task == null) return new NotFoundObjectResult($" {id} Not Found");

            var startedTask = await _taskService.StartAsync(task);

            var responseTask = GetTaskResponse(startedTask);

            return new JsonResult(responseTask);
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> CompleteAsync(Guid id)
        {
            if (id == null || id == Guid.Empty) return new BadRequestResult();

            var task = await _taskService.GetByIdAync(id);

            if (task == null) return new NotFoundObjectResult($" {id} Not Found");

            var completedTask = await _taskService.CompleteAsync(task);

            var responseTask = GetTaskResponse(completedTask);

            return new JsonResult(responseTask);
        }

        [HttpPatch("{id}/open")]
        public async Task<IActionResult> OpenAsync(Guid id)
        {
            if (id == null || id == Guid.Empty) return new BadRequestResult();

            var task = await _taskService.GetByIdAync(id);

            if (task == null) return new NotFoundObjectResult($" {id} Not Found");

            var openTask = await _taskService.OpenAsync(task);

            var responseTask = GetTaskResponse(openTask);

            return new JsonResult(responseTask);
        }

        private TaskResponse GetTaskResponse(TaskModel taskModel)
        {
            return TaskResponse.MapFromTaskModel(taskModel);
        }

    }
}
