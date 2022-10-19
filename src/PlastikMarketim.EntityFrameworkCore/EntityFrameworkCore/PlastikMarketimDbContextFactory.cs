using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PlastikMarketim.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class PlastikMarketimDbContextFactory : IDesignTimeDbContextFactory<PlastikMarketimDbContext>
    {
        public PlastikMarketimDbContext CreateDbContext(string[] args)
        {
            PlastikMarketimEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<PlastikMarketimDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new PlastikMarketimDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PlastikMarketim.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
