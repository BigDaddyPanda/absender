using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AbsenderAPI.Migrations
{
    public partial class addseancetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempsDebut",
                table: "Seance",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TempssFin",
                table: "Seance",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesignationPanier",
                table: "Panier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagPanier",
                table: "Panier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesignationOption",
                table: "Option",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagOption",
                table: "Option",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesignationNiveau",
                table: "Niveau",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagNiveau",
                table: "Niveau",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Coefficient",
                table: "Matiere",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DesignationMatiere",
                table: "Matiere",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagMatiere",
                table: "Matiere",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TauxTolere",
                table: "Matiere",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VolumeHoraire",
                table: "Matiere",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Groupe",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstCoursJour",
                table: "Groupe",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Valeur",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAbsence",
                table: "Absence",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "JustificatifAbsence",
                table: "Absence",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TempsSeance",
                columns: table => new
                {
                    RepresentationHHMM = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempsSeance", x => x.RepresentationHHMM);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seance_TempsDebut",
                table: "Seance",
                column: "TempsDebut");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_TempssFin",
                table: "Seance",
                column: "TempssFin");

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_TempsSeance_TempsDebut",
                table: "Seance",
                column: "TempsDebut",
                principalTable: "TempsSeance",
                principalColumn: "RepresentationHHMM",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_TempsSeance_TempssFin",
                table: "Seance",
                column: "TempssFin",
                principalTable: "TempsSeance",
                principalColumn: "RepresentationHHMM",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seance_TempsSeance_TempsDebut",
                table: "Seance");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_TempsSeance_TempssFin",
                table: "Seance");

            migrationBuilder.DropTable(
                name: "TempsSeance");

            migrationBuilder.DropIndex(
                name: "IX_Seance_TempsDebut",
                table: "Seance");

            migrationBuilder.DropIndex(
                name: "IX_Seance_TempssFin",
                table: "Seance");

            migrationBuilder.DropColumn(
                name: "TempsDebut",
                table: "Seance");

            migrationBuilder.DropColumn(
                name: "TempssFin",
                table: "Seance");

            migrationBuilder.DropColumn(
                name: "DesignationPanier",
                table: "Panier");

            migrationBuilder.DropColumn(
                name: "TagPanier",
                table: "Panier");

            migrationBuilder.DropColumn(
                name: "DesignationOption",
                table: "Option");

            migrationBuilder.DropColumn(
                name: "TagOption",
                table: "Option");

            migrationBuilder.DropColumn(
                name: "DesignationNiveau",
                table: "Niveau");

            migrationBuilder.DropColumn(
                name: "TagNiveau",
                table: "Niveau");

            migrationBuilder.DropColumn(
                name: "Coefficient",
                table: "Matiere");

            migrationBuilder.DropColumn(
                name: "DesignationMatiere",
                table: "Matiere");

            migrationBuilder.DropColumn(
                name: "TagMatiere",
                table: "Matiere");

            migrationBuilder.DropColumn(
                name: "TauxTolere",
                table: "Matiere");

            migrationBuilder.DropColumn(
                name: "VolumeHoraire",
                table: "Matiere");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Groupe");

            migrationBuilder.DropColumn(
                name: "EstCoursJour",
                table: "Groupe");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Valeur",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "DateAbsence",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "JustificatifAbsence",
                table: "Absence");
        }
    }
}
