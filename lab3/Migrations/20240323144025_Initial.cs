using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breakdown",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    info = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    warranty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakdown", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    sale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mechanic",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    midname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    tel_number = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    discount_id = table.Column<int>(type: "int", nullable: false),
                    discount_points = table.Column<int>(type: "int", nullable: false),
                    surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    midname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    tel_number = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    birth_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.id);
                    table.ForeignKey(
                        name: "FK_Client_Discount",
                        column: x => x.discount_id,
                        principalTable: "Discount",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Mechanic-Breakdown",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mechanic_id = table.Column<int>(type: "int", nullable: false),
                    breakdown_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanic-Breakdown", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mechanic-Breakdown_Breakdown",
                        column: x => x.breakdown_id,
                        principalTable: "Breakdown",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Mechanic-Breakdown_Mechanic",
                        column: x => x.mechanic_id,
                        principalTable: "Mechanic",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    color = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    brand = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    mileage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR", x => x.id);
                    table.ForeignKey(
                        name: "FK_CAR_Client",
                        column: x => x.owner_id,
                        principalTable: "Client",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_id = table.Column<int>(type: "int", nullable: false),
                    info = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    reg_price = table.Column<int>(type: "int", nullable: true),
                    reg_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.id);
                    table.ForeignKey(
                        name: "FK_Registration_CAR",
                        column: x => x.car_id,
                        principalTable: "Car",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Registration_Status",
                        column: x => x.status,
                        principalTable: "Status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    breakdown_id = table.Column<int>(type: "int", nullable: true),
                    mechanic_id = table.Column<int>(type: "int", nullable: false),
                    start_time = table.Column<TimeSpan>(type: "time(0)", precision: 0, nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    finish_time = table.Column<TimeSpan>(type: "time(0)", precision: 0, nullable: false),
                    finish_date = table.Column<DateTime>(type: "date", nullable: false),
                    registration_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.id);
                    table.ForeignKey(
                        name: "FK_Slot_Breakdown",
                        column: x => x.breakdown_id,
                        principalTable: "Breakdown",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Slot_Mechanic",
                        column: x => x.mechanic_id,
                        principalTable: "Mechanic",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Slot_Registration",
                        column: x => x.registration_id,
                        principalTable: "Registration",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_owner_id",
                table: "Car",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_Client_discount_id",
                table: "Client",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mechanic-Breakdown_breakdown_id",
                table: "Mechanic-Breakdown",
                column: "breakdown_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mechanic-Breakdown_mechanic_id",
                table: "Mechanic-Breakdown",
                column: "mechanic_id");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_car_id",
                table: "Registration",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_status",
                table: "Registration",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_breakdown_id",
                table: "Slot",
                column: "breakdown_id");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_mechanic_id",
                table: "Slot",
                column: "mechanic_id");

            migrationBuilder.CreateIndex(
                name: "IX_Slot_registration_id",
                table: "Slot",
                column: "registration_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mechanic-Breakdown");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "Breakdown");

            migrationBuilder.DropTable(
                name: "Mechanic");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Discount");
        }
    }
}
