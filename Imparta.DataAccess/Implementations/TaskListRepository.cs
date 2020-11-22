using Imparta.DataAccess.Interfaces;
using Imparta.Domain.Task;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imparta.DataAccess.Implementations
{
    public class TaskListRepository : BaseRepository<TaskList>, ITaskListRepository
    {
        public TaskListRepository(TaskDbContext context) : base(context) { }

        public async Task<IList<TaskList>> GetAllWithTasks()
        {
            return await _context.TaskLists
                .AsNoTracking()
                .Include(x => x.Tasks).ToListAsync();
        }

        public async Task<IList<TaskList>> GetListsForUser(string userId)
        {
            return await _context.TaskLists
                .AsNoTracking()
                .Include(x => x.Tasks).Where(x => x.OwnerId == userId).ToListAsync();
        }

        public async Task<IList<TaskModel>> GetTasks(Guid id)
        {
            return await _context.Tasks
                .AsNoTracking().Where(x => x.TaskList.Id == id).ToListAsync();
        }
    }
}
