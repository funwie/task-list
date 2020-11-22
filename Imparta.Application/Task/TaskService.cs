using Imparta.DataAccess.Interfaces;
using Imparta.Domain.Enums;
using Imparta.Domain.Task;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Imparta.Application.Task
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepo;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepo = taskRepository;
        }

        public async Task<TaskModel> AddAsync(TaskModel task)
        {
            return await _taskRepo.AddAsync(task);
        }

        public async Task<TaskModel> CompleteAsync(TaskModel task)
        {
            if (task == null) throw new ArgumentNullException();
            if (task.Status == TaskModelStatus.Completed) return task;

            return await _taskRepo.ChangeStatusAsync(task, TaskModelStatus.Completed);
        }

        public async Task<IList<TaskModel>> FindAsync(Expression<Func<TaskModel, bool>> predicate, Expression<Func<TaskModel, TaskModel>> order)
        {
            return await _taskRepo.FindAsync(predicate, order);
        }

        public async Task<IList<TaskModel>> GetAllAsync(Expression<Func<TaskModel, TaskModel>> order, int size, int offset)
        {
            return await _taskRepo.GetAllAsync();
        }

        public async Task<IList<TaskModel>> GetAllAsync()
        {
            return await _taskRepo.GetAllAsync();
        }

        public async Task<TaskModel> GetByIdAync(Guid id)
        {
            if (id == Guid.Empty || id == null) return null;
            return await _taskRepo.GetByIdAsync(id);
        }

        public async Task<TaskModel> OpenAsync(TaskModel task)
        {
            if (task == null) throw new ArgumentNullException();
            if (task.Status == TaskModelStatus.Open) return task;

            return await _taskRepo.ChangeStatusAsync(task, TaskModelStatus.Open);
        }

        public async System.Threading.Tasks.Task RemoveAsync(Guid id)
        {
            if (id == Guid.Empty || id == null) return;
            await _taskRepo.DeleteAsync(id);
        }

        public async Task<TaskModel> StartAsync(TaskModel task)
        {
            if (task == null) throw new ArgumentNullException();
            if (task.Status == TaskModelStatus.InProgress) return task;

            return await _taskRepo.ChangeStatusAsync(task, TaskModelStatus.InProgress);
        }

        public async Task<TaskModel> UpdateAsync(TaskModel task)
        {
            if (task == null) throw new ArgumentNullException();
            await _taskRepo.UpdateAsync(task);
            return task;
        }
    }
}
