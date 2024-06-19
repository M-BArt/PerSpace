using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PerSpace.Application.Services;
using PerSpace.Domain.Interfaces;
using PerSpace.Infrastructure.Data.Repositories;

namespace PerSpace.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration.SetConfiguration(configuration);
            
            services.AddScoped<Domain.Services.TodoDomainService>();
            services.AddScoped<ITodoRepository, TodoRepository>();
            
            return services;
        }
    }
}
