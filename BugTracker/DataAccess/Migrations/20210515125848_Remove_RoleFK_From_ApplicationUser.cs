using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Remove_RoleFK_From_ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicaitonUsers_Roles_RoleId",
                table: "ApplicaitonUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicaitonUsers_RoleId",
                table: "ApplicaitonUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ApplicaitonUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "ApplicaitonUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicaitonUsers_RoleId",
                table: "ApplicaitonUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicaitonUsers_Roles_RoleId",
                table: "ApplicaitonUsers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
