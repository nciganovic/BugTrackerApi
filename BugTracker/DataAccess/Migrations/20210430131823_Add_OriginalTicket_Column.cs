using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Add_OriginalTicket_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginalTicketId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OriginalTicketId",
                table: "Tickets",
                column: "OriginalTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Tickets_OriginalTicketId",
                table: "Tickets",
                column: "OriginalTicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tickets_OriginalTicketId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OriginalTicketId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OriginalTicketId",
                table: "Tickets");
        }
    }
}
