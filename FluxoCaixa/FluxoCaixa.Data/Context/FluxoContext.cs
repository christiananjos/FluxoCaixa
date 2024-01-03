using FluxoCaixa.Data.Context.Configurations;
using FluxoCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data
{
    public class FluxoContext : DbContext
    {
        public FluxoContext()
        {
            
        }
        public FluxoContext(DbContextOptions<FluxoContext> contextOptions) : base(contextOptions) { }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FluxoDB;Integrated Security=True");

            //Usar quando tiver a api pronta
            //optionsBuilder.UseSqlServer(Configuration.ConnectionConfiguration
            //                                       .GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaConfiguration());
            modelBuilder.ApplyConfiguration(new TransacaoConfiguration());
        }
    }
}
