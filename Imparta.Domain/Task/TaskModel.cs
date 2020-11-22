using Imparta.Domain.Enums;
using System;

namespace Imparta.Domain.Task
{
    /// <summary>
    /// Represents a task (Named TaskModel to prevent confusion with Async return Task).
    /// </summary>
    public class TaskModel : Entity
    {
        public string Description { get; set; }
        public TaskModelStatus Status { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public TaskList TaskList { get; set; }
    }
}
