using Imparta.Application.Task;
using Imparta.UI.Web.Models;
using Imparta.UI.Web.Requests;
using Imparta.UI.Web.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Imparta.UI.Web.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class TaskListsController : ControllerBase
    {
        private readonly ITaskListService _taskListService;
        private UserManager<ApplicationUser> _userManager;

        public TaskListsController(ITaskListService taskListService, UserManager<ApplicationUser> userManager)
        {
            _taskListService = taskListService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskListResponse>> Get()
        {
            var taskLists = await _taskListService.GetAllAsync(GetCurrentUserId());
            var responseList = TaskListResponse.MapFromTaskList(taskLists);
            return responseList;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (id == null || id == Guid.Empty) return new BadRequestResult();

            var taskLisst = await _taskListService.GetByIdAync(id);

            if (taskLisst == null) return new NotFoundObjectResult($"{id} Not Found");

            return new JsonResult(taskLisst);
        }

        [HttpPost]
        public async Task<ActionResult> Post(TaskListRequest taskListRequest)
        {
            if (taskListRequest == null) return new BadRequestResult();

            var taskLisst = await _taskListService.AddAsync(taskListRequest.MapToTaskList(GetCurrentUserId()));

            return new JsonResult(taskLisst);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] TaskListRequest taskListRequest)
        {
            if (id == null || id == Guid.Empty) new BadRequestResult();

            if (taskListRequest == null) return new BadRequestResult();

            var taskList = await _taskListService.GetByIdAync(id);

            if (taskList == null) return new NotFoundObjectResult($"{id} Not Found");

            taskList.Title = taskListRequest.Title;

            await _taskListService.UpdateAsync(taskList);

            return new JsonResult(taskList);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _taskListService.RemoveAsync(id);
        }

        [HttpGet("{id}/tasks")]
        public async Task<IEnumerable<TaskResponse>> GetTasks(Guid id)
        {
            var tasks = await _taskListService.GetTasksForListWithId(id);
            var responseList = TaskResponse.MapFromTaskModels(tasks, id);
            return responseList;
        }

        private string GetCurrentUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
