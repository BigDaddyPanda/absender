using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AbsenderAPI.Models;
using AbsenderAPI.Models.UniversityModels;

namespace AbsenderAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Absence> Absence { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Groupe> Groupe { get; set; }

        public DbSet<Matiere> Matiere { get; set; }

        public DbSet<Niveau> Niveau { get; set; }

        public DbSet<Option> Option { get; set; }

        public DbSet<Panier> Panier { get; set; }

        public DbSet<Seance> Seance { get; set; }

        public DbSet<TempsSeance> TempsSeance { get; set; }


    }
}
