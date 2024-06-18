using Microsoft.Extensions.DependencyInjection;
using PerSpace.Application.Services;

namespace PerSpace.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {         
            return services;
        }
    }
}
