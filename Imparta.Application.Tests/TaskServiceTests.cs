using Imparta.Application.Task;
using Imparta.DataAccess;
using Imparta.DataAccess.Implementations;
using Imparta.Domain.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Imparta.Application.Tests
{
    /// <summary>
    /// Sample testing with InMemory database
    /// </summary>
    [TestClass]
    public class TaskServiceTests
    {
        private ITaskListService _classInTest;

        private DbContextOptions<TaskDbContext> _options;

        [TestInitialize]
        public void TestInit()
        {
            var builder = new DbContextOptionsBuilder<TaskDbContext>();
            _options = builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        }

        [TestMethod]
        public async System.Threading.Tasks.Task AddAsync_ValidRequest_CreateListAndTask()
        {
            using (var context = new TaskDbContext(_options))
            {
               var taskListRepo = new TaskListRepository(context);
               var taskRepo = new TaskRepository(context);

                var taskList = new TaskList
                {
                    Title = "New List",
                    OwnerId = Guid.NewGuid().ToString(),
                    CreatedDate = DateTimeOffset.Now
                };

                var newTaskList = context.TaskLists.Add(taskList).Entity;

                var task = new TaskModel
                {
                    Description = "Write a Task List",
                    TaskList = newTaskList,
                    CreatedDate = DateTimeOffset.Now,
                    Start = DateTimeOffset.Now,
                    End = DateTimeOffset.Now.AddMinutes(45),
                    Status = Domain.Enums.TaskModelStatus.Open
                };

                var newTask = context.Tasks.Add(task).Entity;
                context.SaveChanges();

                var getListTasks = await context.TaskLists.AsNoTracking().Include(x => x.Tasks).ToListAsync();

                Assert.IsNotNull(newTaskList);
                Assert.IsNotNull(newTask);
                Assert.AreEqual(1, getListTasks.Count);
                Assert.AreEqual(1, getListTasks[0].Tasks.Count);
                Assert.AreEqual(newTask.Id, getListTasks[0].Tasks[0].Id);

                
            }
        }
    }
}
