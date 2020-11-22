using Imparta.Domain.Task;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Imparta.UI.Web.Responses
{
    public class TaskListResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string OwnerId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public IList<TaskResponse> Tasks { get; set; }
        public int TasksCount { get; set; }

        public static IList<TaskListResponse> MapFromTaskList(IList<TaskList> taskLists)
        {
            
            var taskListsResponse = new List<TaskListResponse>();

            if (taskLists == null || !taskLists.Any()) return taskListsResponse;

            foreach (var taskList in taskLists)
            {
                var taskListRes = new TaskListResponse
                {
                    Id = taskList.Id,
                    Title = taskList.Title,
                    CreatedDate = taskList.CreatedDate,
                };

                if (taskList.Tasks != null && taskList.Tasks.Any())
                {
                    taskListRes.TasksCount = taskList.Tasks.Count;
                    taskListRes.Tasks = taskList.Tasks.Select(TaskResponse.MapFromTaskModel).ToList();
                }
                else
                {
                    taskListRes.Tasks = Array.Empty<TaskResponse>();
                }
                    
                taskListsResponse.Add(taskListRes);
            }
            
            return taskListsResponse;
        }
    }

    
}
