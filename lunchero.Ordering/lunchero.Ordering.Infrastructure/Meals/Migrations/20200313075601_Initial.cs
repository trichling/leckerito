using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lunchero.Ordering.Infrastructure.Meals.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ordering");

            migrationBuilder.CreateTable(
                name: "Meals",
                schema: "ordering",
                columns: table => new
                {
                    MealId = table.Column<Guid>(nullable: false),
                    TableguestId = table.Column<Guid>(nullable: false),
                    ArticleNumber = table.Column<string>(nullable: true),
                    PickupOn = table.Column<DateTime>(nullable: false),
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
                schema: "ordering");
        }
    }
}
