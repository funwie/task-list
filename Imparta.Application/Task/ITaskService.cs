using Imparta.Domain.Task;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imparta.Application.Task
{
    public interface ITaskService
    {
        Task<TaskModel> AddAsync(TaskModel task);
        Task<TaskModel> UpdateAsync(TaskModel task);
        Task<TaskModel> CompleteAsync(TaskModel task);
        Task<TaskModel> OpenAsync(TaskModel task);
        Task<TaskModel> StartAsync(TaskModel task);
        Task<TaskModel> GetByIdAync(Guid id);
        Task<IList<TaskModel>> FindAsync(Expression<Func<TaskModel, bool>> predicate, Expression<Func<TaskModel, TaskModel>> order);
        Task<IList<TaskModel>> GetAllAsync(Expression<Func<TaskModel, TaskModel>> order, int size, int offset);
        Task<IList<TaskModel>> GetAllAsync();
        System.Threading.Tasks.Task RemoveAsync(Guid id);
    }
}
