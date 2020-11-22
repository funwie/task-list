using Imparta.Domain.Task;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imparta.DataAccess.Interfaces
{
    public interface ITaskListRepository : IRepository<TaskList>
    {
        Task<IList<TaskList>> GetAllWithTasks();

        Task<IList<TaskModel>> GetTasks(Guid id);

        Task<IList<TaskList>> GetListsForUser(string userId);
    }
}
