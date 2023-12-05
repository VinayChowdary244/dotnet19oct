using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketingWebApplication.Migrations
{
    public partial class driverDetailsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverAge",
                table: "Busses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DriverName",
                table: "Busses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DriverPhone",
                table: "Busses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "DriverRating",
                table: "Busses",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Busses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "Busses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverAge",
                table: "Busses");

            migrationBuilder.DropColumn(
                name: "DriverName",
                table: "Busses");

            migrationBuilder.DropColumn(
                name: "DriverPhone",
                table: "Busses");

            migrationBuilder.DropColumn(
                name: "DriverRating",
                table: "Busses");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Busses");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Busses");
        }
    }
}
