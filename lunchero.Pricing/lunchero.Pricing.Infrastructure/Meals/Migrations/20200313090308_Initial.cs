using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lunchero.Pricing.Infrastructure.Meals.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pricing");

            migrationBuilder.CreateTable(
                name: "Meals",
                schema: "pricing",
                columns: table => new
                {
                    MealId = table.Column<Guid>(nullable: false),
                    TableguestId = table.Column<Guid>(nullable: false),
                    PickupOn = table.Column<DateTime>(nullable: false),
                    ArticleNumber = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meals",
                schema: "pricing");
        }
    }
}
