using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketingWebApplication.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Busses");

            migrationBuilder.DropColumn(
                name: "BookedSeats",
                table: "Busses");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "BookedSeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookedSeatCount",
                table: "BookedSeats",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "BookedSeats");

            migrationBuilder.DropColumn(
                name: "BookedSeatCount",
                table: "BookedSeats");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Busses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookedSeats",
                table: "Busses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
