using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketingWebApplication.Migrations
{
    public partial class datesIncluded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "CancelledBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "BookedSeats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "CancelledBookings");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BookedSeats");
        }
    }
}
