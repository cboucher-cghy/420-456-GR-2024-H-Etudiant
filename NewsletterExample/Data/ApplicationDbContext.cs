using GeniusChuck.NewsletterExample.Models;
using Microsoft.EntityFrameworkCore;

namespace GeniusChuck.NewsletterExample.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscriber>()
                .Property(s => s.RegistrationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
        }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<Person> Personnes { get; set; }
    }
}
