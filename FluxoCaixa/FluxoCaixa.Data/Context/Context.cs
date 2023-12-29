using FluxoCaixa.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
    }
}
