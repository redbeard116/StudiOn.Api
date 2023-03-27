using IdentityService.Extensions;
using Market.Api.Data;
using Market.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Market.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbRepositoryContextFactory>(provider =>
                                   new DbRepositoryContextFactory(configuration.GetConnectionString("MarketConnection")));

            services.AddDbContext<DBService>(option => option.UseNpgsql(configuration.GetConnectionString("MarketConnection")));

            services.AddCustomJwtAuth();

            services.AddScoped<IMarketServices, MarketServices>();

            services.AddControllers().AddNewtonsoftJson(action =>
            {
                action.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
        }
    }
}
