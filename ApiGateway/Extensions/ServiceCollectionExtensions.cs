using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;

namespace ApiGateway.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationProviderKey = "IdentityApiKey";

            services.AddAuthentication()
             .AddJwtBearer(authenticationProviderKey, x =>
             {
                 x.Authority = "https://localhost:5005"; // IDENTITY SERVER URL
                 //x.RequireHttpsMetadata = false;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateAudience = false
                 };
             });

            services.AddOcelot(configuration);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
