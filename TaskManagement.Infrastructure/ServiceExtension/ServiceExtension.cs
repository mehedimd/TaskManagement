using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Core.Interfaces;
using TaskManagement.Infrastructure.DataAccess;
using TaskManagement.Infrastructure.DbContext;

namespace TaskManagement.Infrastructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TaskManagementConnection"));
            });

            // repository DI
            services.AddScoped<ITaskItemRepository,TaskItemRepository>();

            return services;
        }

    }
}
