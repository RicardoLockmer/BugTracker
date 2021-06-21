using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "ID", "TicketActivity", "TicketCategory", "TicketCreator", "TicketDate", "TicketDecription", "TicketName", "TicketOwner" },
                values: new object[] { 999, 1, "Bug", "John Dow", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the word counting for the max limit of characters on each field does not count properly", "Word Count not Working", "Jane Doe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "ID",
                keyValue: 999);
        }
    }
}
