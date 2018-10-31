using AbsenderAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenderAPI.Managers
{
    public class RoleManangement:IRoleManagement
    {
        public enum Roles
        {
            SuperAdministrateur,
            Administrateur,
            Enseignant,
            Etudiant
        }
        private readonly IServiceProvider _serviceProvider;

        public RoleManangement(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async void Initialize()
        {
            using (var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //create database schema if none exists
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                var _roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                foreach (var role in Enum.GetNames(typeof(Roles)))
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
        }

        //public static async Task SeedRoles(IServiceProvider serviceProvider)
        //{
        //    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    foreach (var role in Enum.GetNames(typeof(Roles)))
        //    {
        //        if (!await roleManager.RoleExistsAsync(role))
        //        {
        //            await roleManager.CreateAsync(new IdentityRole(role));
        //        }
        //    }
        //}
    }
}
