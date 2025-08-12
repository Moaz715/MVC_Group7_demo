using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Group7_demo_DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveries_Delivery_id",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "Delivery_id",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliveries_Delivery_id",
                table: "Orders",
                column: "Delivery_id",
                principalTable: "Deliveries",
                principalColumn: "Delivery_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveries_Delivery_id",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "Delivery_id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliveries_Delivery_id",
                table: "Orders",
                column: "Delivery_id",
                principalTable: "Deliveries",
                principalColumn: "Delivery_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
