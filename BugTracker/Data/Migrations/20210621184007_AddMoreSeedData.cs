using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Data.Migrations
{
    public partial class AddMoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "ID", "TicketActivity", "TicketCategory", "TicketCreator", "TicketDate", "TicketDecription", "TicketName", "TicketOwner" },
                values: new object[] { 998, 2, "Feature", "John Doe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Move around the columns and refresh to view that it saved changes with AJAX.", "Drag me to another column", "Jane Doe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 998);
        }
    }
}
