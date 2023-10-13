using Authentication.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Api.Extensions
{
    internal static class DBExtensions
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
}
