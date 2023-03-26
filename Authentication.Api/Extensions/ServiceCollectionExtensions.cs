using Authentication.Api.Data;
using Authentication.Api.Services;
using IdentityService.Extensions;
using Microsoft.EntityFrameworkCore;

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

            services.AddControllers().AddNewtonsoftJson(action =>
            {
                action.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
        }
    }
}
