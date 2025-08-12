using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Group7_demo_DAL.Migrations
{
    /// <inheritdoc />
    public partial class addIsFinalizedAndPaymentMethodAndFinalizedOnInOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "finalizedOn",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isFinalized",
                table: "Orders",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paymentMethod",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "finalizedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "isFinalized",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "paymentMethod",
                table: "Orders");
        }
    }
}
