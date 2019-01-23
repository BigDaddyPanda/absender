﻿// <auto-generated />
using System;
using AbsenderBack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AbsenderBack.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AbsenderAPI.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id_Utilisateur")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Connect");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("Email_Confirm");

                    b.Property<byte[]>("Fichier_Profil");

                    b.Property<string>("Hash_Password");

                    b.Property<string>("IdNational");

                    b.Property<string>("IdUniversitaire");

                    b.Property<string>("NomPrenom");

                    b.Property<string>("PhotoProfil");

                    b.Property<string>("Standarized_Email");

                    b.HasKey("Id_Utilisateur");

                    b.ToTable("ApplicationUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Absence", b =>
                {
                    b.Property<int>("Id_Absence")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_sauvegarde");

                    b.Property<bool>("EstAbsent");

                    b.Property<string>("Fk_Etudiant");

                    b.Property<int>("Fk_Seance");

                    b.Property<string>("Justificatif");

                    b.HasKey("Id_Absence");

                    b.HasIndex("Fk_Etudiant");

                    b.HasIndex("Fk_Seance");

                    b.ToTable("Absence");
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Diplome", b =>
                {
                    b.Property<int>("Id_Diplome")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation_Formation");

                    b.Property<string>("Designation_Orientation");

                    b.Property<string>("Type_Cours");

                    b.HasKey("Id_Diplome");

                    b.ToTable("Diplome");
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Filiere", b =>
                {
                    b.Property<int>("Id_Filiere")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation_Filiere");

                    b.Property<string>("Designation_Niveau");

                    b.Property<string>("Designation_Option");

                    b.Property<int>("Fk_Diplome");

                    b.HasKey("Id_Filiere");

                    b.HasIndex("Fk_Diplome");

                    b.ToTable("Filiere");
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Groupe", b =>
                {
                    b.Property<int>("Id_groupe")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation_groupe");

                    b.Property<int>("Fk_Filiere");

                    b.HasKey("Id_groupe");

                    b.HasIndex("Fk_Filiere");

                    b.ToTable("Groupe");
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Matiere", b =>
                {
                    b.Property<int>("Id_Matiere")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Coefficient");

                    b.Property<string>("Designation_Matiere");

                    b.Property<int>("Fk_Module");

                    b.Property<float>("Limite_Absence");

                    b.HasKey("Id_Matiere");

                    b.HasIndex("Fk_Module");

                    b.ToTable("Matiere");
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Module", b =>
                {
                    b.Property<int>("Id_Module")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation_Module");

                    b.Property<int>("Fk_Filiere");

                    b.HasKey("Id_Module");

                    b.HasIndex("Fk_Filiere");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Seance", b =>
                {
                    b.Property<int>("Id_Seance")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Day_Of_The_Week");

                    b.Property<string>("End_Time");

                    b.Property<int?>("Fk_Groupe");

                    b.Property<int?>("Fk_Matiere");

                    b.Property<string>("Fk_Professeur");

                    b.Property<string>("Start_Time");

                    b.HasKey("Id_Seance");

                    b.HasIndex("Fk_Groupe");

                    b.HasIndex("Fk_Matiere");

                    b.HasIndex("Fk_Professeur");

                    b.ToTable("Seance");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Users.Etudiant", b =>
                {
                    b.HasBaseType("AbsenderAPI.Models.ApplicationUser");

                    b.Property<string>("ContactParent");

                    b.Property<int>("Fk_Groupe");

                    b.HasIndex("Fk_Groupe");

                    b.ToTable("Etudiant");

                    b.HasDiscriminator().HasValue("Etudiant");
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Users.Professeur", b =>
                {
                    b.HasBaseType("AbsenderAPI.Models.ApplicationUser");

                    b.Property<string>("Domaine");

                    b.ToTable("Professeur");

                    b.HasDiscriminator().HasValue("Professeur");
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Absence", b =>
                {
                    b.HasOne("AbsenderAPI.Models.UniversityModels.Users.Etudiant", "Ref_Etudiant")
                        .WithMany("Progres_absence")
                        .HasForeignKey("Fk_Etudiant");

                    b.HasOne("AbsenderAPI.Models.UniversityModels.Seance", "Ref_Seance")
                        .WithMany()
                        .HasForeignKey("Fk_Seance")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Filiere", b =>
                {
                    b.HasOne("AbsenderAPI.Models.UniversityModels.Diplome", "Ref_Diplome")
                        .WithMany()
                        .HasForeignKey("Fk_Diplome")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Groupe", b =>
                {
                    b.HasOne("AbsenderAPI.Models.UniversityModels.Filiere", "Ref_Filiere")
                        .WithMany("Groupes")
                        .HasForeignKey("Fk_Filiere")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Matiere", b =>
                {
                    b.HasOne("AbsenderAPI.Models.UniversityModels.Module", "Ref_Module")
                        .WithMany("Matiere_Associees")
                        .HasForeignKey("Fk_Module")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Module", b =>
                {
                    b.HasOne("AbsenderAPI.Models.UniversityModels.Filiere", "Ref_Filiere")
                        .WithMany("Plan_Modules")
                        .HasForeignKey("Fk_Filiere")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Seance", b =>
                {
                    b.HasOne("AbsenderAPI.Models.UniversityModels.Groupe", "Ref_Groupe")
                        .WithMany("Emploie")
                        .HasForeignKey("Fk_Groupe");

                    b.HasOne("AbsenderAPI.Models.UniversityModels.Matiere", "Ref_Matiere")
                        .WithMany("List_Seances")
                        .HasForeignKey("Fk_Matiere")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AbsenderAPI.Models.UniversityModels.Users.Professeur", "Ref_Professeur")
                        .WithMany("Emploie_Enseignant")
                        .HasForeignKey("Fk_Professeur");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbsenderAPI.Models.UniversityModels.Users.Etudiant", b =>
                {
                    b.HasOne("AbsenderAPI.Models.UniversityModels.Groupe", "Ref_Groupe")
                        .WithMany("Liste_Etudiants")
                        .HasForeignKey("Fk_Groupe")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
