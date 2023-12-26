using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Services.Data;

namespace Product.Services.Extensions;

public static class DBExtensions
{
    public static void SetDatabaseMigrations(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var factory = serviceScope.ServiceProvider.GetRequiredService<IDbRepositoryContextFactory>();
            using (var context = factory.CreateDbContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
