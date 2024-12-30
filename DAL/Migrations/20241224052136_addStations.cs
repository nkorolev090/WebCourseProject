using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addStations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "Mechanic",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultStationId",
                table: "Client",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StationId",
                table: "Mechanic");

            migrationBuilder.DropColumn(
                name: "DefaultStationId",
                table: "Client");
        }
    }
}
