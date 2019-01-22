using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenderBack.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdNational",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUniversitaire",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoProfil",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactParent",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fk_Groupe",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ref_GroupeId_groupe",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Domaine",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fk_Seance",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Diplome",
                columns: table => new
                {
                    Id_Diplome = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designation_Orientation = table.Column<string>(nullable: true),
                    Designation_Formation = table.Column<string>(nullable: true),
                    Type_Cours = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diplome", x => x.Id_Diplome);
                });

            migrationBuilder.CreateTable(
                name: "Filiere",
                columns: table => new
                {
                    Id_Filiere = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designation_Niveau = table.Column<string>(nullable: true),
                    Designation_Filiere = table.Column<string>(nullable: true),
                    Designation_Option = table.Column<string>(nullable: true),
                    Fk_Diplome = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiere", x => x.Id_Filiere);
                    table.ForeignKey(
                        name: "FK_Filiere_Diplome_Fk_Diplome",
                        column: x => x.Fk_Diplome,
                        principalTable: "Diplome",
                        principalColumn: "Id_Diplome",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groupe",
                columns: table => new
                {
                    Id_groupe = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designation_groupe = table.Column<string>(nullable: true),
                    Fk_Filiere = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupe", x => x.Id_groupe);
                    table.ForeignKey(
                        name: "FK_Groupe_Filiere_Fk_Filiere",
                        column: x => x.Fk_Filiere,
                        principalTable: "Filiere",
                        principalColumn: "Id_Filiere",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id_Module = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designation_Module = table.Column<string>(nullable: true),
                    Fk_Filiere = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id_Module);
                    table.ForeignKey(
                        name: "FK_Module_Filiere_Fk_Filiere",
                        column: x => x.Fk_Filiere,
                        principalTable: "Filiere",
                        principalColumn: "Id_Filiere",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    Id_Matiere = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designation_Matiere = table.Column<string>(nullable: true),
                    Coefficient = table.Column<float>(nullable: false),
                    Limite_Absence = table.Column<float>(nullable: false),
                    Fk_Module = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.Id_Matiere);
                    table.ForeignKey(
                        name: "FK_Matiere_Module_Fk_Module",
                        column: x => x.Fk_Module,
                        principalTable: "Module",
                        principalColumn: "Id_Module",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seance",
                columns: table => new
                {
                    Id_Seance = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Start_Time = table.Column<string>(nullable: true),
                    End_Time = table.Column<string>(nullable: true),
                    Fk_Matiere = table.Column<int>(nullable: true),
                    Fk_Professeur = table.Column<string>(nullable: true),
                    Fk_Groupe = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance", x => x.Id_Seance);
                    table.ForeignKey(
                        name: "FK_Seance_Groupe_Fk_Groupe",
                        column: x => x.Fk_Groupe,
                        principalTable: "Groupe",
                        principalColumn: "Id_groupe",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seance_Matiere_Fk_Matiere",
                        column: x => x.Fk_Matiere,
                        principalTable: "Matiere",
                        principalColumn: "Id_Matiere",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seance_AspNetUsers_Fk_Professeur",
                        column: x => x.Fk_Professeur,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Absence",
                columns: table => new
                {
                    Id_Absence = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Justificatif = table.Column<string>(nullable: true),
                    Date_sauvegarde = table.Column<DateTime>(nullable: false),
                    EstAbsent = table.Column<bool>(nullable: false),
                    Fk_Etudiant = table.Column<string>(nullable: true),
                    Fk_Seance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.Id_Absence);
                    table.ForeignKey(
                        name: "FK_Absence_AspNetUsers_Fk_Etudiant",
                        column: x => x.Fk_Etudiant,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Absence_Seance_Fk_Seance",
                        column: x => x.Fk_Seance,
                        principalTable: "Seance",
                        principalColumn: "Id_Seance",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Ref_GroupeId_groupe",
                table: "AspNetUsers",
                column: "Ref_GroupeId_groupe");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Fk_Seance",
                table: "AspNetUsers",
                column: "Fk_Seance");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_Fk_Etudiant",
                table: "Absence",
                column: "Fk_Etudiant");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_Fk_Seance",
                table: "Absence",
                column: "Fk_Seance");

            migrationBuilder.CreateIndex(
                name: "IX_Filiere_Fk_Diplome",
                table: "Filiere",
                column: "Fk_Diplome");

            migrationBuilder.CreateIndex(
                name: "IX_Groupe_Fk_Filiere",
                table: "Groupe",
                column: "Fk_Filiere");

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_Fk_Module",
                table: "Matiere",
                column: "Fk_Module");

            migrationBuilder.CreateIndex(
                name: "IX_Module_Fk_Filiere",
                table: "Module",
                column: "Fk_Filiere");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_Fk_Groupe",
                table: "Seance",
                column: "Fk_Groupe");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_Fk_Matiere",
                table: "Seance",
                column: "Fk_Matiere");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_Fk_Professeur",
                table: "Seance",
                column: "Fk_Professeur");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groupe_Ref_GroupeId_groupe",
                table: "AspNetUsers",
                column: "Ref_GroupeId_groupe",
                principalTable: "Groupe",
                principalColumn: "Id_groupe",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Seance_Fk_Seance",
                table: "AspNetUsers",
                column: "Fk_Seance",
                principalTable: "Seance",
                principalColumn: "Id_Seance",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groupe_Ref_GroupeId_groupe",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Seance_Fk_Seance",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Absence");

            migrationBuilder.DropTable(
                name: "Seance");

            migrationBuilder.DropTable(
                name: "Groupe");

            migrationBuilder.DropTable(
                name: "Matiere");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Filiere");

            migrationBuilder.DropTable(
                name: "Diplome");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Ref_GroupeId_groupe",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Fk_Seance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdNational",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdUniversitaire",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoProfil",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactParent",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fk_Groupe",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ref_GroupeId_groupe",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Domaine",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fk_Seance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
