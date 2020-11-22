using Imparta.DataAccess.Interfaces;
using Imparta.Domain.Enums;
using Imparta.Domain.Task;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Imparta.DataAccess.Implementations
{
    public class TaskRepository : BaseRepository<TaskModel>, ITaskRepository
    {
        public TaskRepository(TaskDbContext context) : base(context) { }

        public async Task<TaskModel> ChangeStatusAsync(TaskModel task, TaskModelStatus status)
        {
            if (task == null) throw new ArgumentNullException("Cannot update null task");

            task.Status = status;

            await base.UpdateAsync(task);

            return task;
        }

        public override async Task<TaskModel> GetByIdAsync(Guid id)
        {
            return await _context.Tasks.AsNoTracking().Include(x => x.TaskList).Where(t => t.Id == id).SingleOrDefaultAsync();
        }
    }
}
