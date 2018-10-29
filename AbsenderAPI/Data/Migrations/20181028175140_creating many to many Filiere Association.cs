using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AbsenderAPI.Data.Migrations
{
    public partial class creatingmanytomanyFiliereAssociation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Module_Filiere_FiliereIdFiliere",
                table: "Module");

            migrationBuilder.DropIndex(
                name: "IX_Module_FiliereIdFiliere",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "FiliereIdFiliere",
                table: "Module");

            migrationBuilder.CreateTable(
                name: "FiliereModuleAssociation",
                columns: table => new
                {
                    IdFiliere = table.Column<int>(nullable: false),
                    IdModule = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiliereModuleAssociation", x => new { x.IdFiliere, x.IdModule });
                    table.ForeignKey(
                        name: "FK_FiliereModuleAssociation_Filiere_IdFiliere",
                        column: x => x.IdFiliere,
                        principalTable: "Filiere",
                        principalColumn: "IdFiliere",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FiliereModuleAssociation_Module_IdModule",
                        column: x => x.IdModule,
                        principalTable: "Module",
                        principalColumn: "IdModule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FiliereModuleAssociation_IdModule",
                table: "FiliereModuleAssociation",
                column: "IdModule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiliereModuleAssociation");

            migrationBuilder.AddColumn<int>(
                name: "FiliereIdFiliere",
                table: "Module",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Module_FiliereIdFiliere",
                table: "Module",
                column: "FiliereIdFiliere");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Filiere_FiliereIdFiliere",
                table: "Module",
                column: "FiliereIdFiliere",
                principalTable: "Filiere",
                principalColumn: "IdFiliere",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
