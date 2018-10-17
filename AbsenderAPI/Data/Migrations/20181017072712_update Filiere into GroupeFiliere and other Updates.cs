using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AbsenderAPI.Data.Migrations
{
    public partial class updateFiliereintoGroupeFiliereandotherUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matiere_Module_ModuleIdModule",
                table: "Matiere");

            migrationBuilder.DropIndex(
                name: "IX_Matiere_ModuleIdModule",
                table: "Matiere");

            migrationBuilder.DropColumn(
                name: "TauxTolereModule",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "ModuleIdModule",
                table: "Matiere");

            migrationBuilder.AddColumn<int>(
                name: "IdModule",
                table: "Matiere",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TauxTolereModule",
                table: "Matiere",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_IdModule",
                table: "Matiere",
                column: "IdModule");

            migrationBuilder.AddForeignKey(
                name: "FK_Matiere_Module_IdModule",
                table: "Matiere",
                column: "IdModule",
                principalTable: "Module",
                principalColumn: "IdModule",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matiere_Module_IdModule",
                table: "Matiere");

            migrationBuilder.DropIndex(
                name: "IX_Matiere_IdModule",
                table: "Matiere");

            migrationBuilder.DropColumn(
                name: "IdModule",
                table: "Matiere");

            migrationBuilder.DropColumn(
                name: "TauxTolereModule",
                table: "Matiere");

            migrationBuilder.AddColumn<int>(
                name: "TauxTolereModule",
                table: "Module",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModuleIdModule",
                table: "Matiere",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_ModuleIdModule",
                table: "Matiere",
                column: "ModuleIdModule");

            migrationBuilder.AddForeignKey(
                name: "FK_Matiere_Module_ModuleIdModule",
                table: "Matiere",
                column: "ModuleIdModule",
                principalTable: "Module",
                principalColumn: "IdModule",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
