using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketingWebApplication.Migrations
{
    public partial class day2dayBookingadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "CancelledBookings");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "CancelledBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
