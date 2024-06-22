using Microsoft.Extensions.DependencyInjection;
using PerSpace.Application.Services.Todo;

namespace PerSpace.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {         
            services.AddScoped<ITodoService, TodoService>();

            return services;
        }
    }
}
