using FluxoCaixa.Domain.Models;
using System.Data.Entity;

namespace FluxoCaixa.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> contextoptions) : base(contextoptions)
        {
        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
    }
}
