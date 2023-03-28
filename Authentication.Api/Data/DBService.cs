using Authentication.Api.Data.Models;
using DatabaseModelsBase;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Api.Data
{
    internal class DBService : BaseDataBaseContext
    {
        public DBService(DbContextOptions<DBService> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>()
               .Property(b => b.Id)
               .HasDefaultValueSql("public.uuid_generate_v4()");

            modelBuilder.Entity<UserType>()
               .Property(b => b.Id)
               .HasDefaultValueSql("public.uuid_generate_v4()");

            modelBuilder.Entity<UserDb>().HasOne(w => w.UserType).WithMany(w => w.Users);

            modelBuilder.Entity<UserDb>().HasIndex(w => w.Login).IsUnique();
            modelBuilder.Entity<UserDb>().HasIndex(w => w.Password);

            modelBuilder.Entity<UserDb>().HasQueryFilter(w => !w.IsDeleted);
            modelBuilder.Entity<UserType>().HasQueryFilter(w => !w.IsDeleted);

            var guid = Guid.NewGuid();
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = guid, Name = "Admin" });
            modelBuilder.Entity<UserDb>().HasData(new UserDb { Id = Guid.NewGuid(), CreateDate = DateTime.Now, Login = "stud_admin", Password = BCrypt.Net.BCrypt.HashPassword("12345678"), UserName = "StudiOn Admin", UserTypeId = guid });
        }

        public DbSet<UserDb> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
