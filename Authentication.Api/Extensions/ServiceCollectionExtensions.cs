using Authentication.Services.Extensions;
using Microsoft.OpenApi.Models;

namespace Authentication.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {         
            services.AddAuthServices(configuration);

            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Authentication API", Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson(action =>
            {
                action.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
        }
    }
}
