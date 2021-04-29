using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Rename_CompanyAndMTMTableMigraiton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyApplicaitonUser_ApplicaitonUsers_ApplicationUserId",
                table: "CompanyApplicaitonUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyApplicaitonUser_Company_CompanyId",
                table: "CompanyApplicaitonUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyApplicaitonUser",
                table: "CompanyApplicaitonUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "CompanyApplicaitonUser",
                newName: "CompanyApplicationUsers");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyApplicaitonUser_ApplicationUserId",
                table: "CompanyApplicationUsers",
                newName: "IX_CompanyApplicationUsers_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_Name",
                table: "Companies",
                newName: "IX_Companies_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyApplicationUsers",
                table: "CompanyApplicationUsers",
                columns: new[] { "CompanyId", "ApplicationUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_CompanyId",
                table: "Project",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyApplicationUsers_ApplicaitonUsers_ApplicationUserId",
                table: "CompanyApplicationUsers",
                column: "ApplicationUserId",
                principalTable: "ApplicaitonUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyApplicationUsers_Companies_CompanyId",
                table: "CompanyApplicationUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyApplicationUsers_ApplicaitonUsers_ApplicationUserId",
                table: "CompanyApplicationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyApplicationUsers_Companies_CompanyId",
                table: "CompanyApplicationUsers");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyApplicationUsers",
                table: "CompanyApplicationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "CompanyApplicationUsers",
                newName: "CompanyApplicaitonUser");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyApplicationUsers_ApplicationUserId",
                table: "CompanyApplicaitonUser",
                newName: "IX_CompanyApplicaitonUser_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_Name",
                table: "Company",
                newName: "IX_Company_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyApplicaitonUser",
                table: "CompanyApplicaitonUser",
                columns: new[] { "CompanyId", "ApplicationUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyApplicaitonUser_ApplicaitonUsers_ApplicationUserId",
                table: "CompanyApplicaitonUser",
                column: "ApplicationUserId",
                principalTable: "ApplicaitonUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyApplicaitonUser_Company_CompanyId",
                table: "CompanyApplicaitonUser",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
