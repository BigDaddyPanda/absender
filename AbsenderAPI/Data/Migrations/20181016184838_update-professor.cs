using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AbsenderAPI.Data.Migrations
{
    public partial class updateprofessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModuleIdModule",
                table: "Matiere",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiliereIdFiliere",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Filiere",
                columns: table => new
                {
                    IdFiliere = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignationClasse = table.Column<string>(nullable: true),
                    DesignationFiliere = table.Column<string>(nullable: true),
                    DesignationOption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiere", x => x.IdFiliere);
                });

            migrationBuilder.CreateTable(
                name: "Salle",
                columns: table => new
                {
                    IdSalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignationSalle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salle", x => x.IdSalle);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    IdModule = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignationModule = table.Column<string>(nullable: true),
                    FiliereIdFiliere = table.Column<int>(nullable: true),
                    TauxTolereModule = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.IdModule);
                    table.ForeignKey(
                        name: "FK_Module_Filiere_FiliereIdFiliere",
                        column: x => x.FiliereIdFiliere,
                        principalTable: "Filiere",
                        principalColumn: "IdFiliere",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_ModuleIdModule",
                table: "Matiere",
                column: "ModuleIdModule");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FiliereIdFiliere",
                table: "AspNetUsers",
                column: "FiliereIdFiliere");

            migrationBuilder.CreateIndex(
                name: "IX_Module_FiliereIdFiliere",
                table: "Module",
                column: "FiliereIdFiliere");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Filiere_FiliereIdFiliere",
                table: "AspNetUsers",
                column: "FiliereIdFiliere",
                principalTable: "Filiere",
                principalColumn: "IdFiliere",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matiere_Module_ModuleIdModule",
                table: "Matiere",
                column: "ModuleIdModule",
                principalTable: "Module",
                principalColumn: "IdModule",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Filiere_FiliereIdFiliere",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Matiere_Module_ModuleIdModule",
                table: "Matiere");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Salle");

            migrationBuilder.DropTable(
                name: "Filiere");

            migrationBuilder.DropIndex(
                name: "IX_Matiere_ModuleIdModule",
                table: "Matiere");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FiliereIdFiliere",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModuleIdModule",
                table: "Matiere");

            migrationBuilder.DropColumn(
                name: "FiliereIdFiliere",
                table: "AspNetUsers");
        }
    }
}
