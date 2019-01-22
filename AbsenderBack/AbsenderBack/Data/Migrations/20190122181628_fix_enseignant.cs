using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenderBack.Data.Migrations
{
    public partial class fix_enseignant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Seance_Fk_Seance",
                table: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_Fk_Seance",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Fk_Seance",
                table: "ApplicationUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fk_Seance",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Fk_Seance",
                table: "ApplicationUsers",
                column: "Fk_Seance");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Seance_Fk_Seance",
                table: "ApplicationUsers",
                column: "Fk_Seance",
                principalTable: "Seance",
                principalColumn: "Id_Seance",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
