using IdentityService.Extensions;

namespace Products.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllers();

            services.AddCustomJwtAuth();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("productClient", "ProductsAPI"));
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
