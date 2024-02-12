using Exercice_Formulaire_Etudiant.Data.Configuration;
using Exercice_Formulaire_Etudiant.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice_Formulaire_Etudiant.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaysConfiguration());
        }

        public DbSet<Pays> Pays { get; set; } = default!;
        public DbSet<Departement> Departements { get; set; } = default!;
        public DbSet<Employe> Employes { get; set; } = default!;
    }


}