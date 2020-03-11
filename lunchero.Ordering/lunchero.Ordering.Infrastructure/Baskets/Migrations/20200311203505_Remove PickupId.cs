using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lunchero.Ordering.Infrastructure.Baskets.Migrations
{
    public partial class RemovePickupId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickupId",
                schema: "ordering",
                table: "BasketItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PickupId",
                schema: "ordering",
                table: "BasketItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
