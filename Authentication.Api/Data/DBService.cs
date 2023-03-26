using Authentication.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Api.Data
{
    internal class DBService : DbContext
    {
        public DBService(DbContextOptions<DBService> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence("users_id_seq", "user");
            modelBuilder.HasSequence("user_types_id_seq", "user");

            modelBuilder.Entity<UserDb>()
               .Property(b => b.Id)
               .HasDefaultValueSql("nextval('user.users_id_seq'::regclass)");

            modelBuilder.Entity<UserType>()
               .Property(b => b.Id)
               .HasDefaultValueSql("nextval('user.user_types_id_seq'::regclass)");

            modelBuilder.Entity<UserDb>().HasOne(w => w.UserType).WithMany(w => w.Users);

            modelBuilder.Entity<UserDb>().HasIndex(w => w.Login).IsUnique();
            modelBuilder.Entity<UserDb>().HasIndex(w => w.Password).IsUnique();

            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 1, Name = "Admin" });
            modelBuilder.Entity<UserDb>().HasData(new UserDb { Id = 1, CreateDate = DateTime.Now, Login = "stud_admin", Password = BCrypt.Net.BCrypt.HashPassword("12345678"), UserName = "StudiOn Admin", UserTypeId = 1 });
        }

        public DbSet<UserDb> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
