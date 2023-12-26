using IdentityService.Models.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Extensions;

public static class JwtAuthExtensions
{
    public static void AddCustomJwtAuth(this IServiceCollection services)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder();
        builder.AddJsonFile("Configurations/auth_options.json");
        var root = builder.Build();
        var authOptions = new AuthOptions();
        root.GetSection("AuthOptions").Bind(authOptions);
        services.AddSingleton(authOptions);
        services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
        services.AddSingleton<IPasswordVerificator, PasswordVerificator>();
        services.AddSingleton(authOptions.GetTokenValidationParameters());
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = authOptions.GetTokenValidationParameters();
        });
    }
}
