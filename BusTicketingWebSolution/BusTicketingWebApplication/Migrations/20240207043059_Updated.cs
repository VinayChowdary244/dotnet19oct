using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketingWebApplication.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "End",
                table: "CancelledBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Start",
                table: "CancelledBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "End",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Start",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "CancelledBookings");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "CancelledBookings");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Bookings");
        }
    }
}
