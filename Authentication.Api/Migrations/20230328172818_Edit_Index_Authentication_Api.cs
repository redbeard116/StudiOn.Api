using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Api.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Index_Authentication_Api : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_password",
                schema: "user",
                table: "users");

            migrationBuilder.DeleteData(
                schema: "user",
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("6ace91a3-90d7-4b94-af67-f5e3f23f1eb6"));

            migrationBuilder.DeleteData(
                schema: "user",
                table: "user_types",
                keyColumn: "id",
                keyValue: new Guid("2d000882-3a29-4f84-94ec-1d98d0c2cfa4"));

            migrationBuilder.InsertData(
                schema: "user",
                table: "user_types",
                columns: new[] { "id", "is_deleted", "name" },
                values: new object[] { new Guid("1f0f2385-e5b4-4338-890c-b0659ac0f3dc"), false, "Admin" });

            migrationBuilder.InsertData(
                schema: "user",
                table: "users",
                columns: new[] { "id", "create_date", "is_blocked", "is_deleted", "login", "password", "user_name", "user_type_id" },
                values: new object[] { new Guid("e900fc53-fe84-4b89-924a-751a90d78aa1"), new DateTime(2023, 3, 28, 20, 28, 18, 259, DateTimeKind.Local).AddTicks(5558), false, false, "stud_admin", "$2a$11$moYbmJ.GJ23x68N0h7cMuOBzioguYksY8yVqvWkWR3Ego4AeHQo8G", "StudiOn Admin", new Guid("1f0f2385-e5b4-4338-890c-b0659ac0f3dc") });

            migrationBuilder.CreateIndex(
                name: "IX_users_password",
                schema: "user",
                table: "users",
                column: "password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_password",
                schema: "user",
                table: "users");

            migrationBuilder.DeleteData(
                schema: "user",
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("e900fc53-fe84-4b89-924a-751a90d78aa1"));

            migrationBuilder.DeleteData(
                schema: "user",
                table: "user_types",
                keyColumn: "id",
                keyValue: new Guid("1f0f2385-e5b4-4338-890c-b0659ac0f3dc"));

            migrationBuilder.InsertData(
                schema: "user",
                table: "user_types",
                columns: new[] { "id", "is_deleted", "name" },
                values: new object[] { new Guid("2d000882-3a29-4f84-94ec-1d98d0c2cfa4"), false, "Admin" });

            migrationBuilder.InsertData(
                schema: "user",
                table: "users",
                columns: new[] { "id", "create_date", "is_blocked", "is_deleted", "login", "password", "user_name", "user_type_id" },
                values: new object[] { new Guid("6ace91a3-90d7-4b94-af67-f5e3f23f1eb6"), new DateTime(2023, 3, 28, 19, 44, 53, 454, DateTimeKind.Local).AddTicks(4135), false, false, "stud_admin", "$2a$11$1BNtntCoqAo1XeVpkxfBXObljF5dbCEJADSRW095XMLNMjiaPlha6", "StudiOn Admin", new Guid("2d000882-3a29-4f84-94ec-1d98d0c2cfa4") });

            migrationBuilder.CreateIndex(
                name: "IX_users_password",
                schema: "user",
                table: "users",
                column: "password",
                unique: true);
        }
    }
}
