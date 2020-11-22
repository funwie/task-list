using Imparta.Domain.Task;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imparta.Application.Task
{
    public interface ITaskListService
    {
        Task<TaskList> AddAsync(TaskList taskList);
        Task<TaskList> UpdateAsync(TaskList taskList);
        Task<TaskList> GetByIdAync(Guid id);
        Task<IList<TaskList>> FindAsync(Expression<Func<TaskList, bool>> predicate, Expression<Func<TaskList, TaskList>> order);
        Task<IList<TaskList>> GetAllAsync(string userId);
        Task<IList<TaskModel>> GetTasksForListWithId(Guid id);
        System.Threading.Tasks.Task RemoveAsync(Guid id);
    }
}
