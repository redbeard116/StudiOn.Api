using IdentityService.Extensions;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;

namespace ApiGateway.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomJwtAuth();
            services.AddOcelot(configuration);

            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "All API", Version = "v1" });
            });

            services.AddSwaggerForOcelot(configuration);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
