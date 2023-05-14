using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirLines",
                columns: table => new
                {
                    AirLineCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirLineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLines", x => x.AirLineCode);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirLineCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightCode);
                });

            migrationBuilder.CreateTable(
                name: "Journey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirLineCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPassengers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirLines");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Journey");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
