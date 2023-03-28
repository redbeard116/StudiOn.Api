using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Api.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Index_Market_Api : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_markets_name",
                schema: "market",
                table: "markets");

            migrationBuilder.CreateIndex(
                name: "IX_markets_name",
                schema: "market",
                table: "markets",
                column: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_markets_name",
                schema: "market",
                table: "markets");

            migrationBuilder.CreateIndex(
                name: "IX_markets_name",
                schema: "market",
                table: "markets",
                column: "name",
                unique: true);
        }
    }
}
