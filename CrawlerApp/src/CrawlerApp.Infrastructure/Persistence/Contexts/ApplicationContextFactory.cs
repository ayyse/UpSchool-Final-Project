using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CrawlerApp.Infrastructure.Persistence.Contexts
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            optionsBuilder.UseMySql("", serverVersion);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
