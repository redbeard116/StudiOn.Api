﻿// <auto-generated />
using System;
using Authentication.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Authentication.Services.Migrations
{
    [DbContext(typeof(DBService))]
    [Migration("20230328172818_Edit_Index_Authentication_Api")]
    partial class Edit_Index_Authentication_Api
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Authentication.Services.Data.Models.UserDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("public.uuid_generate_v4()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean")
                        .HasColumnName("is_blocked");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.Property<Guid>("UserTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_type_id");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("Password");

                    b.HasIndex("UserTypeId");

                    b.ToTable("users", "user");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e900fc53-fe84-4b89-924a-751a90d78aa1"),
                            CreateDate = new DateTime(2023, 3, 28, 20, 28, 18, 259, DateTimeKind.Local).AddTicks(5558),
                            IsBlocked = false,
                            IsDeleted = false,
                            Login = "stud_admin",
                            Password = "$2a$11$moYbmJ.GJ23x68N0h7cMuOBzioguYksY8yVqvWkWR3Ego4AeHQo8G",
                            UserName = "StudiOn Admin",
                            UserTypeId = new Guid("1f0f2385-e5b4-4338-890c-b0659ac0f3dc")
                        });
                });

            modelBuilder.Entity("Authentication.Services.Data.Models.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("public.uuid_generate_v4()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("user_types", "user");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1f0f2385-e5b4-4338-890c-b0659ac0f3dc"),
                            IsDeleted = false,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Authentication.Services.Data.Models.UserDb", b =>
                {
                    b.HasOne("Authentication.Services.Data.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Authentication.Services.Data.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}