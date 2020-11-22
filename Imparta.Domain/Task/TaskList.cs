using System;
using System.Collections.Generic;

namespace Imparta.Domain.Task
{
    public class TaskList : Entity
    {
        public TaskList()
        {
            Tasks = new List<TaskModel>();
        }
       
        public string Title { get; set; }
        public string OwnerId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public IList<TaskModel> Tasks { get; set; }
    }
}
