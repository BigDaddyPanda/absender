using System;
using System.Collections.Generic;
using System.Text;
using AbsenderAPI.Models;
using AbsenderAPI.Models.UniversityModels;
using AbsenderAPI.Models.UniversityModels.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AbsenderBack.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Seance>()
            .HasOne(p => p.Ref_Matiere)
            .WithMany(b => b.List_Seances)
            .OnDelete(DeleteBehavior.Restrict);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Diplome> Diplome { get; set; }
        public DbSet<Filiere> Filiere { get; set; }
        public DbSet<Groupe> Groupe { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Etudiant> Etudiant { get; set; }
        public DbSet<Matiere> Matiere { get; set; }
        public DbSet<Professeur> Professeur { get; set; }
        public DbSet<Seance> Seance { get; set; }
        public DbSet<Absence> Absence { get; set; }

    }
}
