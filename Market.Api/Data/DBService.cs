using Market.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Api.Data
{
    internal class DBService : DbContext
    {
        public DBService(DbContextOptions<DBService> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence("markets_id_seq", "market");

            modelBuilder.Entity<MarketDb>()
              .Property(b => b.Id)
              .HasDefaultValueSql("nextval('market.markets_id_seq'::regclass)");

            modelBuilder.Entity<MarketDb>().HasIndex(w => w.Id).IsUnique();
            modelBuilder.Entity<MarketDb>().HasIndex(w => w.Name).IsUnique();
        }
    }
}
