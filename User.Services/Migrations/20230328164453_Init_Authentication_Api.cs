using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Services.Migrations
{
    /// <inheritdoc />
    public partial class Init_Authentication_Api : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.CreateTable(
                name: "user_types",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "public.uuid_generate_v4()"),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "public.uuid_generate_v4()"),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    user_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    is_blocked = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_user_types_user_type_id",
                        column: x => x.user_type_id,
                        principalSchema: "user",
                        principalTable: "user_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_users_login",
                schema: "user",
                table: "users",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_password",
                schema: "user",
                table: "users",
                column: "password",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_user_type_id",
                schema: "user",
                table: "users",
                column: "user_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users",
                schema: "user");

            migrationBuilder.DropTable(
                name: "user_types",
                schema: "user");
        }
    }
}
