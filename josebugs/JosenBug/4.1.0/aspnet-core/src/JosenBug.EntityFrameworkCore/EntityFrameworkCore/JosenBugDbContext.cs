using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using JosenBug.Authorization.Roles;
using JosenBug.Authorization.Users;
using JosenBug.MultiTenancy;
using JosenBug.Plano;


namespace JosenBug.EntityFrameworkCore
{
    public class JosenBugDbContext : AbpZeroDbContext<Tenant, Role, User, JosenBugDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Classificacao> ClassificacaoPlano { get; set; }
        public DbSet<Cobertura> CoberturaPlano { get; set; }
        public DbSet<Plano.Plano> Plano { get; set; }

        public JosenBugDbContext(DbContextOptions<JosenBugDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var planoBuilder = modelBuilder.Entity<Plano.Plano>();
            planoBuilder.ToTable("Plano");
            planoBuilder.Property(p => p.Nome).HasColumnName("Nome");
            planoBuilder.Property(p => p.CodigoANS).HasColumnName("CodigoANS");
            planoBuilder.Property(p => p.IDClassificacaoPlano).HasColumnName("IDClassificacaoPlano");
            planoBuilder.Property(p => p.IDCobertura).HasColumnName("IDCobertura");
            planoBuilder.HasKey("Id");
            planoBuilder.HasOne(p => p.Classificacao)
                .WithMany()
                .HasForeignKey(p => p.IDClassificacaoPlano);
            planoBuilder.HasOne(p => p.Cobertura)
                .WithMany()
                .HasForeignKey(p => p.IDCobertura);

            var classificacaoBuilder = modelBuilder.Entity<Classificacao>();
            classificacaoBuilder.Property(p => p.Nome).HasColumnName("Descricao");
            classificacaoBuilder.Property(p => p.Id).HasColumnName("IdClassificacaoPlano");
            classificacaoBuilder.HasKey(p => p.Id);

            var coberturaBuilder = modelBuilder.Entity<Cobertura>();
            coberturaBuilder.Property(p => p.Nome).HasColumnName("Nome");
            coberturaBuilder.Property(p => p.Id).HasColumnName("Id");
            coberturaBuilder.HasKey(p => p.Id);



        }

    }
}
