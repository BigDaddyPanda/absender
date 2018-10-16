using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AbsenderAPI.Data.Migrations
{
    public partial class updatestrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    IdMatiere = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignationMatiere = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.IdMatiere);
                });

            migrationBuilder.CreateTable(
                name: "Absence",
                columns: table => new
                {
                    IdAbsence = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdMatiere = table.Column<int>(nullable: false),
                    IdUtilisateur = table.Column<string>(nullable: true),
                    MessageAbsence = table.Column<string>(nullable: true),
                    TauxAbsence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.IdAbsence);
                    table.ForeignKey(
                        name: "FK_Absence_Matiere_IdMatiere",
                        column: x => x.IdMatiere,
                        principalTable: "Matiere",
                        principalColumn: "IdMatiere",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absence_AspNetUsers_IdUtilisateur",
                        column: x => x.IdUtilisateur,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absence_IdMatiere",
                table: "Absence",
                column: "IdMatiere");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_IdUtilisateur",
                table: "Absence",
                column: "IdUtilisateur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absence");

            migrationBuilder.DropTable(
                name: "Matiere");
        }
    }
}
