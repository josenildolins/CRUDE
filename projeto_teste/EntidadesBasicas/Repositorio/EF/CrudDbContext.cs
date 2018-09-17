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
            //TODO mandar para o arquivo de configuração e ler de lá (vá estudar pra saber como)
            optionsBuilder.UseSqlServer(@"Server=192.168.1.206;Database=JosenBugs;User Id=josenbugs;Password=josenbugs123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO fazer mapeamento completo, use o de classificação como exemplo básico
            
            //Mapeamento de classificacao
            var classificacaoBuilder = modelBuilder.Entity<ClassificacaoPlano>();
            classificacaoBuilder.ToTable("ClassificacaoPlano");
            classificacaoBuilder.Property(p => p.Descricao).HasColumnName("Descricao");
            classificacaoBuilder.Property(p => p.Id).HasColumnName("IdClassificacaoPlano");
            classificacaoBuilder.HasKey(p => p.Id);
            //======================

            //Mapeamento de Cobertura
            modelBuilder.Entity<CoberturaPlano>().HasKey("IdCobertura");
            //======================
            

            //Mapeamento de Cobertura
            var planoBuilder = modelBuilder.Entity<Plano>();

            planoBuilder.HasOne(p => p.ClassificacaoPlano)
                .WithMany()
                .HasForeignKey(p => p.IdClassificacaoPlano);

            planoBuilder.HasKey("IdPlano");
            //======================

        }

        public DbSet<ClassificacaoPlano> ClassificacaoPlano { get; set; }
        public DbSet<CoberturaPlano> CoberturaPlano { get; set;}
        public DbSet<Plano> Planos { get; set; }
        
     
    }
}
