using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCart4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "CartItem",
                newName: "cart_id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                newName: "IX_CartItem_cart_id");

            migrationBuilder.RenameColumn(
                name: "PromocodeId",
                table: "Cart",
                newName: "promocode_id");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Cart",
                newName: "client_id");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_PromocodeId",
                table: "Cart",
                newName: "IX_Cart_promocode_id");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_ClientId",
                table: "Cart",
                newName: "IX_Cart_client_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cart_id",
                table: "CartItem",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_cart_id",
                table: "CartItem",
                newName: "IX_CartItem_CartId");

            migrationBuilder.RenameColumn(
                name: "promocode_id",
                table: "Cart",
                newName: "PromocodeId");

            migrationBuilder.RenameColumn(
                name: "client_id",
                table: "Cart",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_promocode_id",
                table: "Cart",
                newName: "IX_Cart_PromocodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_client_id",
                table: "Cart",
                newName: "IX_Cart_ClientId");
        }
    }
}
