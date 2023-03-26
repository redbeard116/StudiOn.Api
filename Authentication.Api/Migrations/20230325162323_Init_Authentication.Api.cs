using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init_AuthenticationApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.CreateSequence(
                name: "user_types_id_seq",
                schema: "user");

            migrationBuilder.CreateSequence(
                name: "users_id_seq",
                schema: "user");

            migrationBuilder.CreateTable(
                name: "user_types",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('user.user_types_id_seq'::regclass)"),
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
                    id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('user.users_id_seq'::regclass)"),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    user_type_id = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                values: new object[] { 1, false, "Admin" });

            migrationBuilder.InsertData(
                schema: "user",
                table: "users",
                columns: new[] { "id", "create_date", "is_blocked", "is_deleted", "login", "password", "user_name", "user_type_id" },
                values: new object[] { 1, new DateTime(2023, 3, 25, 19, 23, 22, 497, DateTimeKind.Local).AddTicks(8879), false, false, "stud_admin", "$2a$11$HI/5apZk.FRXhkRZiP54xer1li/vbX.GANXjCUqyG0OiD/vRcAa/O", "StudiOn Admin", 1 });

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

            migrationBuilder.DropSequence(
                name: "user_types_id_seq",
                schema: "user");

            migrationBuilder.DropSequence(
                name: "users_id_seq",
                schema: "user");
        }
    }
}
