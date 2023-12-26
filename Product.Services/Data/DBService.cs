using DatabaseModelsBase;
using Microsoft.EntityFrameworkCore;
using Product.Services.Data.Models;

namespace Product.Services.Data
{
    internal class DBService : BaseDataBaseContext
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

            modelBuilder.Entity<ProductDb>().HasQueryFilter(w => !w.IsDeleted);
        }

        public DbSet<ProductDb> Products { get; set; }
    }
}
