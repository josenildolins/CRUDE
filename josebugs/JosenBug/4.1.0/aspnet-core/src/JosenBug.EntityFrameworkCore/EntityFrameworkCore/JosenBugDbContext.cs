using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using JosenBug.Authorization.Roles;
using JosenBug.Authorization.Users;
using JosenBug.MultiTenancy;

namespace JosenBug.EntityFrameworkCore
{
    public class JosenBugDbContext : AbpZeroDbContext<Tenant, Role, User, JosenBugDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public JosenBugDbContext(DbContextOptions<JosenBugDbContext> options)
            : base(options)
        {
        }
    }
}
