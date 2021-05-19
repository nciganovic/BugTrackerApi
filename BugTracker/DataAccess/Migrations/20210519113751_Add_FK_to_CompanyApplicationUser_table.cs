using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Add_FK_to_CompanyApplicationUser_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "CompanyApplicationUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyApplicationUsers_RoleId",
                table: "CompanyApplicationUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyApplicationUsers_Roles_RoleId",
                table: "CompanyApplicationUsers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyApplicationUsers_Roles_RoleId",
                table: "CompanyApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_CompanyApplicationUsers_RoleId",
                table: "CompanyApplicationUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "CompanyApplicationUsers");
        }
    }
}
