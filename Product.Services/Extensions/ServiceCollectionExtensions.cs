using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Services.Data;
using System.Reflection;

namespace Product.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddProductServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddSingleton<IDbRepositoryContextFactory>(provider =>
                                new DbRepositoryContextFactory(configuration.GetConnectionString("ProductConnection")));

        services.AddDbContext<DBService>(option => option.UseNpgsql(configuration.GetConnectionString("ProductConnection")));
    }
}
