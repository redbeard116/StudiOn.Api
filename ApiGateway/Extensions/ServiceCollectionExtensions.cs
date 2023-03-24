using IdentityService.Extensions;
using Ocelot.DependencyInjection;

namespace ApiGateway.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomJwtAuth();
            services.AddOcelot(configuration);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
