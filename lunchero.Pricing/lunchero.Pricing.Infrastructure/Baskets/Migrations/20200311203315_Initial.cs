using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lunchero.Pricing.Infrastructure.Baskets.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pricing");

            migrationBuilder.CreateTable(
                name: "BasketItems",
                schema: "pricing",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BasketId = table.Column<Guid>(nullable: false),
                    ArticleNumber = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    LinePrice = table.Column<decimal>(nullable: false),
                    IsCheckedOut = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems",
                schema: "pricing");
        }
    }
}
