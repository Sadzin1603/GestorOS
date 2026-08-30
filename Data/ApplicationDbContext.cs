using GestorOS.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorOS.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Cliente> Clientes { get; set; } = null;
        public DbSet<OrdemServico> OrdensServico { get; set; } = null;
        public DbSet<CategoriaServico> Servico { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //regras de negocio
            modelBuilder.Entity<OrdemServico>()
                .HasOne(c => c.Cliente)
                .WithMany(o => o.Ordens)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrdemServico>()
                .HasOne(c => c.CategoriaServico)
                .WithMany(o => o.Ordens)
                .HasForeignKey(o => o.CategoriaServicoId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CategoriaServico>().HasData(
                new CategoriaServico { Id = 1, Nome = "Manutenção", Descricao = "Reparos e manutenção geral" },
                new CategoriaServico { Id = 2, Nome = "Instalação", Descricao = "Instalação de equipamentos" },
                new CategoriaServico { Id = 3, Nome = "Consultoria", Descricao = "Consultoria técnica e suporte" }
                );
        }

    }
}
