using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using JosenBug.Configuration;
using JosenBug.Web;

namespace JosenBug.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class JosenBugDbContextFactory : IDesignTimeDbContextFactory<JosenBugDbContext>
    {
        public JosenBugDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<JosenBugDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            JosenBugDbContextConfigurer.Configure(builder, configuration.GetConnectionString(JosenBugConsts.ConnectionStringName));

            return new JosenBugDbContext(builder.Options);
        }
    }
}
