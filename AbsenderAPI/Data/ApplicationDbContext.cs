using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AbsenderAPI.Models;
using AbsenderAPI.Models.UniversityModels;
using AbsenderAPI.Models.AccountViewModels;

namespace AbsenderAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<AbsenderAPI.Models.UniversityModels.Absence> Absence { get; set; }

        public DbSet<AbsenderAPI.Models.UniversityModels.Contact> Contact { get; set; }

        public DbSet<AbsenderAPI.Models.UniversityModels.Groupe> Groupe { get; set; }

        public DbSet<AbsenderAPI.Models.UniversityModels.Matiere> Matiere { get; set; }

        public DbSet<AbsenderAPI.Models.UniversityModels.Niveau> Niveau { get; set; }

        public DbSet<AbsenderAPI.Models.UniversityModels.Option> Option { get; set; }

        public DbSet<AbsenderAPI.Models.UniversityModels.Panier> Panier { get; set; }

        public DbSet<AbsenderAPI.Models.UniversityModels.Seance> Seance { get; set; }


    }
}
