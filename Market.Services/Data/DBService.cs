using DatabaseModelsBase;
using Market.Services.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Services.Data;

internal class DBService : BaseDataBaseContext
{
    public DBService(DbContextOptions<DBService> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MarketDb>()
          .Property(b => b.Id)
          .HasDefaultValueSql("public.uuid_generate_v4()");

        modelBuilder.Entity<MarketDb>().HasIndex(w => w.Id).IsUnique();
        modelBuilder.Entity<MarketDb>().HasIndex(w => w.Name);

        modelBuilder.Entity<MarketDb>().HasQueryFilter(w => !w.IsDeleted);
    }
}
