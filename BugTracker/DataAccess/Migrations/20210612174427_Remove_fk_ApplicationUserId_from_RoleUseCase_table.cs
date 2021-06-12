using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Remove_fk_ApplicationUserId_from_RoleUseCase_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleCases_ApplicaitonUsers_ApplicationUserId",
                table: "RoleCases");

            migrationBuilder.DropIndex(
                name: "IX_RoleCases_ApplicationUserId",
                table: "RoleCases");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "RoleCases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "RoleCases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleCases_ApplicationUserId",
                table: "RoleCases",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleCases_ApplicaitonUsers_ApplicationUserId",
                table: "RoleCases",
                column: "ApplicationUserId",
                principalTable: "ApplicaitonUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
