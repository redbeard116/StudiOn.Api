﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init_Market_Api : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "market");

            migrationBuilder.CreateSequence(
                name: "markets_id_seq",
                schema: "market");

            migrationBuilder.CreateTable(
                name: "markets",
                schema: "market",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('market.markets_id_seq'::regclass)"),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_markets", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_markets_id",
                schema: "market",
                table: "markets",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_markets_name",
                schema: "market",
                table: "markets",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "markets",
                schema: "market");

            migrationBuilder.DropSequence(
                name: "markets_id_seq",
                schema: "market");
        }
    }
}
