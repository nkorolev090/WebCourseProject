using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addDefCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StationId",
                table: "Mechanic",
                newName: "station_id");

            migrationBuilder.RenameColumn(
                name: "DefaultStationId",
                table: "Client",
                newName: "default_station_id");

            migrationBuilder.AddColumn<int>(
                name: "default_car_id",
                table: "Client",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "default_car_id",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "station_id",
                table: "Mechanic",
                newName: "StationId");

            migrationBuilder.RenameColumn(
                name: "default_station_id",
                table: "Client",
                newName: "DefaultStationId");
        }
    }
}
