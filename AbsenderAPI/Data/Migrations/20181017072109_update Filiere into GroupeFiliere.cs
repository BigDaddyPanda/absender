using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AbsenderAPI.Data.Migrations
{
    public partial class updateFiliereintoGroupeFiliere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Filiere_FiliereIdFiliere",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_Filiere_IdFiliere",
                table: "Seance");

            migrationBuilder.DropIndex(
                name: "IX_Seance_IdFiliere",
                table: "Seance");

            migrationBuilder.DropColumn(
                name: "EstCoursSoire",
                table: "Filiere");

            migrationBuilder.RenameColumn(
                name: "DesignationClasse",
                table: "Filiere",
                newName: "TagOption");

            migrationBuilder.RenameColumn(
                name: "FiliereIdFiliere",
                table: "AspNetUsers",
                newName: "GroupeIdGroupe");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_FiliereIdFiliere",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GroupeIdGroupe");

            migrationBuilder.AddColumn<int>(
                name: "IdGroupe",
                table: "Seance",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagFiliere",
                table: "Filiere",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groupe",
                columns: table => new
                {
                    IdGroupe = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignationGroupe = table.Column<string>(nullable: true),
                    EstCoursSoire = table.Column<bool>(nullable: false),
                    IdFiliere = table.Column<int>(nullable: false),
                    NombreEtudiant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupe", x => x.IdGroupe);
                    table.ForeignKey(
                        name: "FK_Groupe_Filiere_IdFiliere",
                        column: x => x.IdFiliere,
                        principalTable: "Filiere",
                        principalColumn: "IdFiliere",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seance_IdGroupe",
                table: "Seance",
                column: "IdGroupe");

            migrationBuilder.CreateIndex(
                name: "IX_Groupe_IdFiliere",
                table: "Groupe",
                column: "IdFiliere");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groupe_GroupeIdGroupe",
                table: "AspNetUsers",
                column: "GroupeIdGroupe",
                principalTable: "Groupe",
                principalColumn: "IdGroupe",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_Groupe_IdGroupe",
                table: "Seance",
                column: "IdGroupe",
                principalTable: "Groupe",
                principalColumn: "IdGroupe",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groupe_GroupeIdGroupe",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_Groupe_IdGroupe",
                table: "Seance");

            migrationBuilder.DropTable(
                name: "Groupe");

            migrationBuilder.DropIndex(
                name: "IX_Seance_IdGroupe",
                table: "Seance");

            migrationBuilder.DropColumn(
                name: "IdGroupe",
                table: "Seance");

            migrationBuilder.DropColumn(
                name: "TagFiliere",
                table: "Filiere");

            migrationBuilder.RenameColumn(
                name: "TagOption",
                table: "Filiere",
                newName: "DesignationClasse");

            migrationBuilder.RenameColumn(
                name: "GroupeIdGroupe",
                table: "AspNetUsers",
                newName: "FiliereIdFiliere");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GroupeIdGroupe",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_FiliereIdFiliere");

            migrationBuilder.AddColumn<bool>(
                name: "EstCoursSoire",
                table: "Filiere",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Seance_IdFiliere",
                table: "Seance",
                column: "IdFiliere");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Filiere_FiliereIdFiliere",
                table: "AspNetUsers",
                column: "FiliereIdFiliere",
                principalTable: "Filiere",
                principalColumn: "IdFiliere",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_Filiere_IdFiliere",
                table: "Seance",
                column: "IdFiliere",
                principalTable: "Filiere",
                principalColumn: "IdFiliere",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
