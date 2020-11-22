using Imparta.Domain.Enums;
using Imparta.Domain.Task;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Imparta.UI.Web.Responses
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public TaskModelStatus Status { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid TaskListId { get; set; }
        public string StatusName { get; set; }

        public bool Completed { get => this.Status == TaskModelStatus.Completed; }
        public bool InProgress { get => this.Status == TaskModelStatus.InProgress; }
        public bool Open { get => this.Status == TaskModelStatus.Open; }
        public bool Overdue { get => this.End <= DateTimeOffset.Now; }

        public static TaskResponse MapFromTaskModel(TaskModel taskModel)
        {
            if (taskModel == null) return null;

            return new TaskResponse
            {
                Id = taskModel.Id,
                Description = taskModel.Description,
                Status = taskModel.Status,
                Start = taskModel.Start,
                End = taskModel.End,
                TaskListId = taskModel.TaskList != null ? taskModel.TaskList.Id : Guid.Empty,
                CreatedDate = taskModel.CreatedDate,
                StatusName = taskModel.Status.ToString()
            };
        }

        public static IList<TaskResponse> MapFromTaskModels(IList<TaskModel> tasks, Guid taskId)
        {
            if (tasks == null || !tasks.Any()) return Array.Empty<TaskResponse>();

            return tasks.Select(x => {
                var mappedTask = MapFromTaskModel(x);
                mappedTask.TaskListId = taskId;
                return mappedTask;
            }).ToList();
        }
    }
}
