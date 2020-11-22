using Imparta.Application.Task;
using Microsoft.Extensions.DependencyInjection;

namespace Imparta.Application
{
    public static class ConfigureApplicationServices
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<ITaskService, TaskService>()
                .AddTransient<ITaskListService, TaskListService>();
        }
    }
}
