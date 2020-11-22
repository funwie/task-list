using Imparta.DataAccess.Implementations;
using Imparta.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Imparta.DataAccess
{
    public static class ConfigureDataAccessServices
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TaskDbContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Imparta.DataAccess")));

            services
                .AddScoped<ITaskRepository, TaskRepository>()
                .AddScoped<ITaskListRepository, TaskListRepository>();
        }
    }
}
