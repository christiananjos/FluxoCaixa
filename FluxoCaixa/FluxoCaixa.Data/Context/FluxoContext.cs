using FluxoCaixa.Data.Context.Configurations;
using FluxoCaixa.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data
{
    public class FluxoContext : DbContext
    {
        public FluxoContext(DbContextOptions<FluxoContext> contextOptions) : base(contextOptions) { }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Data Source=Christian;Initial Catalog=FluxoDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaConfiguration());
            modelBuilder.ApplyConfiguration(new TransacaoConfiguration());
        }
    }
}
