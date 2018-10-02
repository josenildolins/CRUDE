using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace JosenBug.EntityFrameworkCore
{
    public static class JosenBugDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<JosenBugDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<JosenBugDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
