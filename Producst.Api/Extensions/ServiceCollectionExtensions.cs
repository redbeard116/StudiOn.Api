using IdentityService.Extensions;

namespace Products.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomJwtAuth();

            services.AddControllers().AddNewtonsoftJson(action =>
            {
                action.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
        }
    }
}
