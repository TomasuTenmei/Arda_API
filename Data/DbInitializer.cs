using Arda_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Arda_API.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Définir les rôles par défaut
            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    // Créer le rôle et l'ajouter à la base de données
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Créer un utilisateur administrateur par défaut
            var adminUser = new ApplicationUser
            {
                UserName = "admin@arda.com",
                Email = "admin@arda.com",
                EmailConfirmed = true
            };

            string adminPassword = "Admin@123"; // Vous devriez utiliser un mot de passe plus sécurisé

            var user = await userManager.FindByEmailAsync(adminUser.Email);
            if (user == null)
            {
                var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
                if (createAdminUser.Succeeded)
                {
                    // Ajouter l'utilisateur au rôle Admin
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

        public static async Task InitializeDataAsync(ApplicationDbContext context)
        {
            // Vérifiez si des anneaux existent déjà pour éviter les doublons
            if (!context.Rings.Any())
            {
                context.Rings.AddRange(
                    new Ring { Name = "The One Ring", Description = "The Master Ring" },
                    new Ring { Name = "Narya", Description = "The Ring of Fire" },
                    new Ring { Name = "Nenya", Description = "The Ring of Water" },
                    new Ring { Name = "Vilya", Description = "The Ring of Air" }
                    // Ajoutez d'autres objets ici
                );
                await context.SaveChangesAsync();
            }

            // Vérifiez s'il y a d'autres entités à ajouter, comme Characters, Weapons, etc.
            if (!context.Characters.Any())
            {
                context.Characters.AddRange(
                    new Character { Name = "Frodo Baggins", Race = "Hobbit", Description = "The ring-bearer" },
                    new Character { Name = "Gandalf", Race = "Maia", Description = "The Grey Wizard" }
                    // Ajoutez d'autres personnages ici
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
