using IdentityService.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Producst.Api.Data;
using Producst.Api.Services;

namespace Products.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbRepositoryContextFactory>(provider =>
                                    new DbRepositoryContextFactory(configuration.GetConnectionString("ProductConnection")));

            services.AddDbContext<DBService>(option => option.UseNpgsql(configuration.GetConnectionString("ProductConnection")));

            services.AddCustomJwtAuth();

            services.AddScoped<IProductServices, ProductServices>();

            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Products API", Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson(action =>
            {
                action.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
        }
    }
}
