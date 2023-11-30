using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketingWebApplication.Migrations
{
    public partial class UserIdRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Buses",
                table: "Buses");

            migrationBuilder.RenameTable(
                name: "Buses",
                newName: "Busses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bookings",
                newName: "UserName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Busses",
                table: "Busses",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Busses",
                table: "Busses");

            migrationBuilder.RenameTable(
                name: "Busses",
                newName: "Buses");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Bookings",
                newName: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buses",
                table: "Buses",
                column: "Id");
        }
    }
}
