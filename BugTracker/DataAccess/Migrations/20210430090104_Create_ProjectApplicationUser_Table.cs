using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Create_ProjectApplicationUser_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectApplicationUsers",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectApplicationUsers", x => new { x.ProjectId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_ProjectApplicationUsers_ApplicaitonUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicaitonUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectApplicationUsers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApplicationUsers_ApplicationUserId",
                table: "ProjectApplicationUsers",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectApplicationUsers");
        }
    }
}
