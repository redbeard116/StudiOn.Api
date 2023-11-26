using Authentication.Services.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IdentityService.Extensions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAuthServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        serviceCollection.AddSingleton<IDbRepositoryContextFactory>(provider =>
                                   new DbRepositoryContextFactory(configuration.GetConnectionString("UserConnection")));

        serviceCollection.AddDbContext<DBService>(option => option.UseNpgsql(configuration.GetConnectionString("UserConnection")));

        serviceCollection.AddCustomJwtAuth();
    }
}
