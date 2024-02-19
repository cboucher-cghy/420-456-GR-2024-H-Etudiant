using GeniusChuck.Newsletter.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GeniusChuck.Newsletter.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscriber>()
                .Property(s => s.RegistrationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()")
                .HasComment("Indique la date/heure de son inscription");

            modelBuilder.Entity<CategorySubscriber>().HasKey(cs => new { cs.CategoryId, cs.SubscriberId });

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Subscribers)
                .WithMany(x => x.Categories)
                .UsingEntity<CategorySubscriber>()
                .Property(s => s.SubscriptionDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()")
                .HasComment("Indique la date/heure de son inscription pour une catégorie donnée!");

            //modelBuilder.Entity<Subscriber>()
            //    .HasMany(x => x.Categories)
            //    .WithMany(x => x.Subscribers)
            //    .UsingEntity<CategorySubscriber>()
            //    .Property(s => s.SubscriptionDate)
            //    .ValueGeneratedOnAdd()
            //    .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Category>().HasData([
                new Category() { Id = 1, Name = "Sport", Description = "Vive le sport." },
                new Category() { Id = 2, Name = "Culture", Description = "Vive la culture." },
                new Category() { Id = 3, Name = "Politique", Description = "Vive la politique." },
                new Category() { Id = 5, Name = "Jeux vidéo", Description = "Vive les jeux vidéo." }
            ]);
        }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategorySubscriber> CategorySubscriber { get; set; }
    }
}
