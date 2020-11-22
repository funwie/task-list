using Imparta.Application.Task;
using Imparta.DataAccess.Interfaces;
using Imparta.Domain.Task;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Imparta.Application.Tests
{
    /// <summary>
    /// Sample testing with Mocking
    /// </summary>
    [TestClass]
    public class TaskListServiceTests
    {
        private ITaskListService _classInTest;

        private Mock<ITaskListRepository> _taskListRepo;

        [TestInitialize]
        public void TestInit()
        {
            _taskListRepo = new Mock<ITaskListRepository>();
            _classInTest = new TaskListService(_taskListRepo.Object);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task AddAsync_TaskList_ValidRequest_DelegatesToRepo()
        {
            var taskList = new TaskList
            {
                Title = "New List",
                OwnerId = Guid.NewGuid().ToString(),
                CreatedDate = DateTimeOffset.Now
            };

            var newId = Guid.NewGuid();

            var returnList = new TaskList
            {   Id = newId,
                Title = taskList.Title,
                OwnerId = taskList.OwnerId,
                CreatedDate = taskList.CreatedDate
            };

            _taskListRepo.Setup(x => x.AddAsync(taskList)).Verifiable();
            var createdList = await _classInTest.AddAsync(taskList);

            _taskListRepo.Verify(m => m.AddAsync(It.IsAny<TaskList>()), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async System.Threading.Tasks.Task AddAsync_TaskList_NullRequest_ThrowExpection()
        {
            await _classInTest.AddAsync(null);
        }
    }
}
