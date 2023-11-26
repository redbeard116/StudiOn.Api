using Market.Services.Extensions;
using Microsoft.OpenApi.Models;

namespace Market.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMarketServices(configuration);

            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Market API", Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson(action =>
            {
                action.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
        }
    }
}
