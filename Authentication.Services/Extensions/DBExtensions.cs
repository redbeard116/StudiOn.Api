using Authentication.Services.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Services.Extensions;

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
