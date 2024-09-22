using Repository;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
namespace SaccoOps.ContextRactory
{
    public class RepositoryContextFactory :IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                a => a.MigrationsAssembly("SaccoOps"));
            return new ApplicationDbContext(builder.Options);
        }
    }
}

