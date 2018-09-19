using EntidadesBasicas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repositorio.EF
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

           
            string connectionString = configuration.GetConnectionString("Default");

            optionsBuilder.UseSqlServer(connectionString);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var classificacaoBuilder = modelBuilder.Entity<ClassificacaoPlano>();
            classificacaoBuilder.ToTable("ClassificacaoPlano");
            classificacaoBuilder.Property(p => p.Descricao).HasColumnName("Descricao");
            classificacaoBuilder.Property(p => p.Id).HasColumnName("IdClassificacaoPlano");
            classificacaoBuilder.HasKey(p => p.Id);

            var coberturaBuilder = modelBuilder.Entity<CoberturaPlano>();
            coberturaBuilder.ToTable("CoberturaPlano");
            coberturaBuilder.Property(p => p.Nome).HasColumnName("Nome");
            coberturaBuilder.Property(p => p.Id).HasColumnName("IDCobertura");
            coberturaBuilder.HasKey(p => p.Id);

            var planoBuilder = modelBuilder.Entity<Plano>();
            planoBuilder.ToTable("Plano");
            planoBuilder.Property(p => p.Nome).HasColumnName("Nome");
            planoBuilder.Property(p => p.IdClassificacaoPlano).HasColumnName("IDClassificacaoPlano");
            planoBuilder.Property(p => p.CodigoAns).HasColumnName("CodigoANS");
            planoBuilder.Property(p => p.Id).HasColumnName("IDPlano");
            planoBuilder.Property(p => p.IdCobertura).HasColumnName("IDCobertura");

            planoBuilder.HasOne(p => p.ClassificacaoPlano)
                .WithMany()
                .HasForeignKey(p => p.IdClassificacaoPlano);

            planoBuilder.HasOne(p => p.Cobertura)
                .WithMany().HasForeignKey(p => p.IdCobertura);



        }

        public DbSet<ClassificacaoPlano> ClassificacaoPlano { get; set; }
        public DbSet<CoberturaPlano> CoberturaPlano { get; set; }
        public DbSet<Plano> Planos { get; set; }


    }
}
