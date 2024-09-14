using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Arda_API.Models;

namespace Arda_API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Ring> Rings { get; set; }
        public DbSet<Character> Characters { get; set; }
        // Ajoutez d'autres DbSets pour vos autres modèles
    }
}
