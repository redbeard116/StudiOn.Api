using Authentication.Api.Data;
using Authentication.Api.Services;
using IdentityService.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Authentication.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbRepositoryContextFactory>(provider =>
                                   new DbRepositoryContextFactory(configuration.GetConnectionString("UserConnection")));

            services.AddDbContext<DBService>(option=> option.UseNpgsql(configuration.GetConnectionString("UserConnection")));
            
            services.AddCustomJwtAuth();

            services.AddScoped<IAuthService, AuthService>();

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
