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
            return await _taskListRepo.AddAsync(taskList);
        }

        public async Task<IList<TaskList>> FindAsync(Expression<Func<TaskList, bool>> predicate, Expression<Func<TaskList, TaskList>> order)
        {
            return await _taskListRepo.FindAsync(predicate, order);
        }

        public async Task<IList<TaskList>> GetAllAsync(string userId)
        {
            return await _taskListRepo.GetListsForUser(userId);
        }

        public async Task<TaskList> GetByIdAync(Guid id)
        {
            return await _taskListRepo.GetByIdAsync(id);
        }

        public async Task<IList<TaskModel>> GetTasksForListWithId(Guid id)
        {
            return await _taskListRepo.GetTasks(id);
        }

        public async System.Threading.Tasks.Task RemoveAsync(Guid id)
        {
            await _taskListRepo.DeleteAsync(id);
        }

        public async Task<TaskList> UpdateAsync(TaskList taskList)
        {
            await _taskListRepo.UpdateAsync(taskList);
            return taskList;
        }
    }
}
