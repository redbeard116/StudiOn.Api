using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Services.Migrations
{
    /// <inheritdoc />
    public partial class Init_Product_Api : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "product");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "public.uuid_generate_v4()"),
                    market_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<int>(type: "integer", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                schema: "product",
                table: "Product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_id",
                schema: "product",
                table: "Product",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_market_id",
                schema: "product",
                table: "Product",
                column: "market_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_name",
                schema: "product",
                table: "Product",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_Product_price",
                schema: "product",
                table: "Product",
                column: "price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "product");
        }
    }
}
