using EntidadesBasicas;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.EF
{
    public class CrudDbContext:DbContext
    {
        public CrudDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=192.168.1.206;Database=JosenBugs;User Id=josenbugs;Password=josenbugs123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassificacaoPlano>().HasKey("IdClassificacaoPlano");

            modelBuilder.Entity<CoberturaPlano>().HasKey("IdCobertura");

            modelBuilder.Entity<Plano>().HasKey("IdPlano");
            

        }
        
        public DbSet<ClassificacaoPlano> ClassificacaoPlano { get; set; }
        public DbSet<CoberturaPlano> CoberturaPlano { get; set;}
        public DbSet<Plano> plano { get; set; }
        
     
    }
}
