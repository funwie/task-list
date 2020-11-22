using Imparta.Domain.Enums;
using Imparta.Domain.Task;
using System;
using System.ComponentModel.DataAnnotations;

namespace Imparta.Web.Requests
{
    public class TaskRequest
    {
        [Required]
        [MinLength(3), MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public TaskModelStatus Status { get; set; }

        [Required]
        public DateTimeOffset Start { get; set; }

        [Required]
        public DateTimeOffset End { get; set; }

        [Required]
        public Guid TaskListId { get; set; }

        // Simple mapping. better to use AutoMapper
        public TaskModel MapToTaskModel(TaskList taskList)
        {
            return new TaskModel
            {
                Description = this.Description,
                Status = this.Status,
                Start = this.Start,
                End = this.End,
                CreatedDate = DateTimeOffset.Now,
                TaskList = taskList
            };
        }
    }
}
