using GeniusChuck.Newsletter.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace EFCore_Seeder
{
    internal static class DbContextFactory
    {
        public static ApplicationDbContext CreateDbContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/appsettings.json")
                .AddJsonFile(@Directory.GetCurrentDirectory() + $"/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new ApplicationDbContext(builder.Options);
        }

    }
}
