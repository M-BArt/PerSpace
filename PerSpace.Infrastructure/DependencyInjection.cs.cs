using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PerSpace.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration.SetConfiguration(configuration);

            return services;
        }
    }
}
