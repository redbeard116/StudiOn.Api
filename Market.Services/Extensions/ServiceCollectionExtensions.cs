using Market.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Market.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddMarketServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        serviceCollection.AddSingleton<IDbRepositoryContextFactory>(provider =>
                                   new DbRepositoryContextFactory(configuration.GetConnectionString("DbConnection")));

        serviceCollection.AddDbContext<DBService>(option => option.UseNpgsql(configuration.GetConnectionString("DbConnection")));

    }
}
