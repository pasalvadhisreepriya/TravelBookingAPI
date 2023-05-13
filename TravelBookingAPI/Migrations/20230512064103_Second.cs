using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Journey",
                table: "Journey");

            migrationBuilder.AlterColumn<string>(
                name: "FlightCode",
                table: "Journey",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Journey",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journey",
                table: "Journey",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Journey",
                table: "Journey");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Journey");

            migrationBuilder.AlterColumn<string>(
                name: "FlightCode",
                table: "Journey",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journey",
                table: "Journey",
                column: "FlightCode");
        }
    }
}
