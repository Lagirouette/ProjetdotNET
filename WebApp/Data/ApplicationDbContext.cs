using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Classe> Classes { get; set; }
    }
}
