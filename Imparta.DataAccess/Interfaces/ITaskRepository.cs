using Imparta.Domain.Enums;
using Imparta.Domain.Task;
using System;
using System.Threading.Tasks;

namespace Imparta.DataAccess.Interfaces
{
    public interface ITaskRepository : IRepository<TaskModel>
    {
        Task<TaskModel> ChangeStatusAsync(TaskModel task, TaskModelStatus status);
    }
}
