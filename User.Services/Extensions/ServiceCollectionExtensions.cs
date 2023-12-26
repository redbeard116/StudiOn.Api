using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using User.Services.Data;

namespace User.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAuthServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        serviceCollection.AddSingleton<IDbRepositoryContextFactory>(provider =>
                                   new DbRepositoryContextFactory(configuration.GetConnectionString("DbConnection")));

        serviceCollection.AddDbContext<DBService>(option => option.UseNpgsql(configuration.GetConnectionString("DbConnection")));
    }
}
