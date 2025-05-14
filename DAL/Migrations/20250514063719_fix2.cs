using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Cart",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Slot",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_SlotId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "SlotId",
                table: "CartItem");

            migrationBuilder.AlterColumn<int>(
                name: "slot_id",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cart_id",
                table: "CartItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_cart_id",
                table: "CartItem",
                column: "cart_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Cart",
                table: "CartItem",
                column: "cart_id",
                principalTable: "Cart",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Slot",
                table: "CartItem",
                column: "slot_id",
                principalTable: "Slot",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Cart",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Slot",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_cart_id",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "cart_id",
                table: "CartItem");

            migrationBuilder.AlterColumn<int>(
                name: "slot_id",
                table: "CartItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SlotId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_SlotId",
                table: "CartItem",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Cart",
                table: "CartItem",
                column: "slot_id",
                principalTable: "Cart",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Slot",
                table: "CartItem",
                column: "SlotId",
                principalTable: "Slot",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
