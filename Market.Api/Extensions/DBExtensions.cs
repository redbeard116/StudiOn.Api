using Market.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Market.Api.Extensions
{
    internal static class DBExtensions
    {
        public static void SetDatabaseMigrations(this IApplicationBuilder app)
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
