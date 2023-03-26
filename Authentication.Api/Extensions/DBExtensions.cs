using Authentication.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Api.Extensions
{
    internal static class DBExtensions
    {
        internal static void SetDatabaseMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var factory = serviceScope.ServiceProvider.GetRequiredService<IDbRepositoryContextFactory>();
                var context = factory.CreateDbContext();

                context.Database.Migrate();
            }
        }
    }
}
