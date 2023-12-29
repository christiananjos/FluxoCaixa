using FluxoCaixa.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data
{
    public class FluxoContext : DbContext
    {
        public FluxoContext(DbContextOptions<FluxoContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
    }
}
