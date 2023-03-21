using Microsoft.IdentityModel.Tokens;

namespace Products.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllers();

            services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "https://localhost:5005";
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false,
                            ValidateLifetime = true
                        };
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("productClient", "ProductsAPI"));
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
