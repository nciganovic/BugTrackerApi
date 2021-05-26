using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Change_ProjectApplicationUser_name_To_ProjectApplicationUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyApplicationUsers");

            migrationBuilder.CreateTable(
                name: "CompanyApplicationUserRoles",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyApplicationUserRoles", x => new { x.CompanyId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_CompanyApplicationUserRoles_ApplicaitonUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicaitonUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyApplicationUserRoles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyApplicationUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyApplicationUserRoles_ApplicationUserId",
                table: "CompanyApplicationUserRoles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyApplicationUserRoles_RoleId",
                table: "CompanyApplicationUserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyApplicationUserRoles");

            migrationBuilder.CreateTable(
                name: "CompanyApplicationUsers",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyApplicationUsers", x => new { x.CompanyId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_CompanyApplicationUsers_ApplicaitonUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicaitonUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyApplicationUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyApplicationUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyApplicationUsers_ApplicationUserId",
                table: "CompanyApplicationUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyApplicationUsers_RoleId",
                table: "CompanyApplicationUsers",
                column: "RoleId");
        }
    }
}
