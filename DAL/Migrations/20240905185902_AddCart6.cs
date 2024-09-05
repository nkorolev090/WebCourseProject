using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCart6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cart_id",
                table: "CartItem",
                newName: "slot_id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_cart_id",
                table: "CartItem",
                newName: "IX_CartItem_slot_id");

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
                name: "FK_CartItem_Slot",
                table: "CartItem",
                column: "SlotId",
                principalTable: "Slot",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Slot",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_SlotId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "SlotId",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "slot_id",
                table: "CartItem",
                newName: "cart_id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_slot_id",
                table: "CartItem",
                newName: "IX_CartItem_cart_id");
        }
    }
}
