using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lunchero.Ordering.Infrastructure.Orders.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ordering");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    PickupId = table.Column<Guid>(nullable: false),
                    ArticleNumber = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    OrderedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders",
                schema: "ordering");
        }
    }
}
