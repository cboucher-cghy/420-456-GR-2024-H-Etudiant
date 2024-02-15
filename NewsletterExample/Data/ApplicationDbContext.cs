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
        }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategorySubscriber> CategorySubscriber { get; set; }
    }
}
