using Microsoft.EntityFrameworkCore;
using Producst.Api.Data.Models;

namespace Producst.Api.Data
{
    internal class DBService : DbContext
    {
        public DBService(DbContextOptions<DBService> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDb>()
                .Property(b => b.Id)
                .HasDefaultValueSql("public.uuid_generate_v4()");

            modelBuilder.Entity<ProductDb>().HasIndex(w => w.Id).IsUnique();
            modelBuilder.Entity<ProductDb>().HasIndex(w => w.MarketId);
            modelBuilder.Entity<ProductDb>().HasIndex(w => w.CategoryId);
            modelBuilder.Entity<ProductDb>().HasIndex(w => w.Price);
            modelBuilder.Entity<ProductDb>().HasIndex(w => w.Name);
        }

        public DbSet<ProductDb> Products { get; set; }
    }
}
