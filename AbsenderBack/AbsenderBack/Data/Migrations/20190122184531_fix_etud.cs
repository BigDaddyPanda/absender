using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenderBack.Data.Migrations
{
    public partial class fix_etud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Groupe_Ref_GroupeId_groupe",
                table: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_Ref_GroupeId_groupe",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Ref_GroupeId_groupe",
                table: "ApplicationUsers");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Fk_Groupe",
                table: "ApplicationUsers",
                column: "Fk_Groupe");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Groupe_Fk_Groupe",
                table: "ApplicationUsers",
                column: "Fk_Groupe",
                principalTable: "Groupe",
                principalColumn: "Id_groupe",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Groupe_Fk_Groupe",
                table: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_Fk_Groupe",
                table: "ApplicationUsers");

            migrationBuilder.AddColumn<int>(
                name: "Ref_GroupeId_groupe",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Ref_GroupeId_groupe",
                table: "ApplicationUsers",
                column: "Ref_GroupeId_groupe");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Groupe_Ref_GroupeId_groupe",
                table: "ApplicationUsers",
                column: "Ref_GroupeId_groupe",
                principalTable: "Groupe",
                principalColumn: "Id_groupe",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
