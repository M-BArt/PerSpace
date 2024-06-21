using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PerSpace.Application.Services;
using PerSpace.Domain.Interfaces.Todo;
using PerSpace.Infrastructure.Data.Repositories.Todo;

namespace PerSpace.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration.SetConfiguration(configuration);
            
            
            services.AddScoped<ITodoRepository, TodoRepository>();
            
            return services;
        }
    }
}
