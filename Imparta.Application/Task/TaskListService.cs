using Imparta.DataAccess.Interfaces;
using Imparta.Domain.Task;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imparta.Application.Task
{
    public class TaskListService : ITaskListService
    {
        private readonly ITaskListRepository _taskListRepo;

        public TaskListService(ITaskListRepository taskListRepository)
        {
            _taskListRepo = taskListRepository;
        }

        public async Task<TaskList> AddAsync(TaskList taskList)
        {
            if (taskList == null) throw new ArgumentNullException();

            return await _taskListRepo.AddAsync(taskList);
        }

        public async Task<IList<TaskList>> FindAsync(Expression<Func<TaskList, bool>> predicate, Expression<Func<TaskList, TaskList>> order)
        {
            return await _taskListRepo.FindAsync(predicate, order);
        }

        public async Task<IList<TaskList>> GetAllAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException();

            return await _taskListRepo.GetListsForUser(userId);
        }

        public async Task<TaskList> GetByIdAync(Guid id)
        {
            if (id == null || id == Guid.Empty) throw new ArgumentNullException();

            return await _taskListRepo.GetByIdAsync(id);
        }

        public async Task<IList<TaskModel>> GetTasksForListWithId(Guid id)
        {
            if (id == null || id == Guid.Empty) throw new ArgumentNullException();

            return await _taskListRepo.GetTasks(id);
        }

        public async System.Threading.Tasks.Task RemoveAsync(Guid id)
        {
            if (id == null || id == Guid.Empty) throw new ArgumentNullException();

            await _taskListRepo.DeleteAsync(id);
        }

        public async Task<TaskList> UpdateAsync(TaskList taskList)
        {
            if (taskList == null) throw new ArgumentNullException();

            await _taskListRepo.UpdateAsync(taskList);
            return taskList;
        }
    }
}
