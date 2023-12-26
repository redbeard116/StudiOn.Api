﻿using DatabaseModelsBase;
using Microsoft.EntityFrameworkCore;
using User.Services.Data.Models;

namespace User.Services.Data;

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

        modelBuilder.Entity<UserTypeDB>()
           .Property(b => b.Id)
           .HasDefaultValueSql("public.uuid_generate_v4()");

        modelBuilder.Entity<UserDb>().HasOne(w => w.UserType).WithMany(w => w.Users);

        modelBuilder.Entity<UserDb>().HasIndex(w => w.Login).IsUnique();
        modelBuilder.Entity<UserDb>().HasIndex(w => w.Password);

        modelBuilder.Entity<UserDb>().HasQueryFilter(w => !w.IsDeleted);
        modelBuilder.Entity<UserTypeDB>().HasQueryFilter(w => !w.IsDeleted);

        var guid = Guid.NewGuid();
        modelBuilder.Entity<UserTypeDB>().HasData(new UserTypeDB { Id = guid, Name = "Admin" });
        modelBuilder.Entity<UserDb>().HasData(new UserDb { Id = Guid.NewGuid(), CreateDate = DateTime.Now, Login = "stud_admin", Password = BCrypt.Net.BCrypt.HashPassword("12345678"), UserName = "StudiOn Admin", UserTypeId = guid });
    }

    public DbSet<UserDb> Users { get; set; }
    public DbSet<UserTypeDB> UserTypes { get; set; }
}
