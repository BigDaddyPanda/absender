using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AbsenderAPI.Data.Migrations
{
    public partial class updatecourssoir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstCoursSoire",
                table: "Filiere",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Seance",
                columns: table => new
                {
                    IdSseance = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HeureSeance = table.Column<int>(nullable: false),
                    IdFiliere = table.Column<int>(nullable: false),
                    IdProfesseur = table.Column<string>(nullable: true),
                    IdSalle = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance", x => x.IdSseance);
                    table.ForeignKey(
                        name: "FK_Seance_Filiere_IdFiliere",
                        column: x => x.IdFiliere,
                        principalTable: "Filiere",
                        principalColumn: "IdFiliere",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seance_AspNetUsers_IdProfesseur",
                        column: x => x.IdProfesseur,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seance_Salle_IdSalle",
                        column: x => x.IdSalle,
                        principalTable: "Salle",
                        principalColumn: "IdSalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seance_IdFiliere",
                table: "Seance",
                column: "IdFiliere");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_IdProfesseur",
                table: "Seance",
                column: "IdProfesseur");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_IdSalle",
                table: "Seance",
                column: "IdSalle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seance");

            migrationBuilder.DropColumn(
                name: "EstCoursSoire",
                table: "Filiere");
        }
    }
}
