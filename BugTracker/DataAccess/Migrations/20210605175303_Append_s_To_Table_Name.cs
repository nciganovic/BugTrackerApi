using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Append_s_To_Table_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCase_ApplicaitonUsers_ApplicationUserId",
                table: "ApplicationUserCase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserCase",
                table: "ApplicationUserCase");

            migrationBuilder.RenameTable(
                name: "ApplicationUserCase",
                newName: "ApplicationUserCases");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserCase_ApplicationUserId",
                table: "ApplicationUserCases",
                newName: "IX_ApplicationUserCases_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserCases",
                table: "ApplicationUserCases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCases_ApplicaitonUsers_ApplicationUserId",
                table: "ApplicationUserCases",
                column: "ApplicationUserId",
                principalTable: "ApplicaitonUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCases_ApplicaitonUsers_ApplicationUserId",
                table: "ApplicationUserCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserCases",
                table: "ApplicationUserCases");

            migrationBuilder.RenameTable(
                name: "ApplicationUserCases",
                newName: "ApplicationUserCase");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserCases_ApplicationUserId",
                table: "ApplicationUserCase",
                newName: "IX_ApplicationUserCase_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserCase",
                table: "ApplicationUserCase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCase_ApplicaitonUsers_ApplicationUserId",
                table: "ApplicationUserCase",
                column: "ApplicationUserId",
                principalTable: "ApplicaitonUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
