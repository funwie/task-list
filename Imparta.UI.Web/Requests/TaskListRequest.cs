using Imparta.Domain.Task;
using System;
using System.ComponentModel.DataAnnotations;

namespace Imparta.UI.Web.Requests
{
    public class TaskListRequest
    {
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Title { get; set; }

        // Simple mapping. better to use AutoMapper
        public virtual TaskList MapToTaskList(string ownerId)
        {
            return new TaskList
            {
                Title = this.Title,
                CreatedDate = DateTimeOffset.Now,
                OwnerId = ownerId
            };
        }
    }
}
