using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Fix_typo_in_developer_id_column_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ApplicaitonUsers_DevloperId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "DevloperId",
                table: "Tickets",
                newName: "DeveloperId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_DevloperId",
                table: "Tickets",
                newName: "IX_Tickets_DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ApplicaitonUsers_DeveloperId",
                table: "Tickets",
                column: "DeveloperId",
                principalTable: "ApplicaitonUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ApplicaitonUsers_DeveloperId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "DeveloperId",
                table: "Tickets",
                newName: "DevloperId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_DeveloperId",
                table: "Tickets",
                newName: "IX_Tickets_DevloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ApplicaitonUsers_DevloperId",
                table: "Tickets",
                column: "DevloperId",
                principalTable: "ApplicaitonUsers",
                principalColumn: "Id");
        }
    }
}
