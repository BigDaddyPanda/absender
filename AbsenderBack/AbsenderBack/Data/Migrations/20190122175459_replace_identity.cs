using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenderBack.Data.Migrations
{
    public partial class replace_identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_AspNetUsers_Fk_Etudiant",
                table: "Absence");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groupe_Ref_GroupeId_groupe",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Seance_Fk_Seance",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_AspNetUsers_Fk_Professeur",
                table: "Seance");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id_Utilisateur = table.Column<string>(nullable: false),
                    IdNational = table.Column<string>(nullable: true),
                    IdUniversitaire = table.Column<string>(nullable: true),
                    PhotoProfil = table.Column<string>(nullable: true),
                    Fichier_Profil = table.Column<byte[]>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Standarized_Email = table.Column<string>(nullable: true),
                    Hash_Password = table.Column<string>(nullable: true),
                    Email_Confirm = table.Column<bool>(nullable: false),
                    Connect = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ContactParent = table.Column<string>(nullable: true),
                    Fk_Groupe = table.Column<int>(nullable: true),
                    Ref_GroupeId_groupe = table.Column<int>(nullable: true),
                    Domaine = table.Column<string>(nullable: true),
                    Fk_Seance = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id_Utilisateur);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Groupe_Ref_GroupeId_groupe",
                        column: x => x.Ref_GroupeId_groupe,
                        principalTable: "Groupe",
                        principalColumn: "Id_groupe",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Seance_Fk_Seance",
                        column: x => x.Fk_Seance,
                        principalTable: "Seance",
                        principalColumn: "Id_Seance",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Ref_GroupeId_groupe",
                table: "ApplicationUsers",
                column: "Ref_GroupeId_groupe");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Fk_Seance",
                table: "ApplicationUsers",
                column: "Fk_Seance");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_ApplicationUsers_Fk_Etudiant",
                table: "Absence",
                column: "Fk_Etudiant",
                principalTable: "ApplicationUsers",
                principalColumn: "Id_Utilisateur",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_ApplicationUsers_Fk_Professeur",
                table: "Seance",
                column: "Fk_Professeur",
                principalTable: "ApplicationUsers",
                principalColumn: "Id_Utilisateur",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_ApplicationUsers_Fk_Etudiant",
                table: "Absence");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_ApplicationUsers_Fk_Professeur",
                table: "Seance");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

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

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Ref_GroupeId_groupe",
                table: "AspNetUsers",
                column: "Ref_GroupeId_groupe");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Fk_Seance",
                table: "AspNetUsers",
                column: "Fk_Seance");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_AspNetUsers_Fk_Etudiant",
                table: "Absence",
                column: "Fk_Etudiant",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_AspNetUsers_Fk_Professeur",
                table: "Seance",
                column: "Fk_Professeur",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
