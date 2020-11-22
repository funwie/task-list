using Imparta.Domain.Task;
using System;

namespace Imparta.Web.Request
{
    public class UpdateTaskRequest : TaskRequest
    {
        public Guid Id { get; set; }
        public  TaskModel MapToTask(TaskModel tastToupdate)
        {
            return new TaskModel
            {
                Description = this.Description,
                Status = this.Status,
                Start = this.Start,
                End = this.End,
                CreatedDate = DateTimeOffset.Now,
                Id = this.Id,
            };
        }
    }
}
