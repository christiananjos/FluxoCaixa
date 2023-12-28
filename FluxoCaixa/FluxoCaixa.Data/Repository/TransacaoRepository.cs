using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Models;

namespace FluxoCaixa.Data.Repository
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly TransacaoDbContext _dbContext;

        public TransacaoRepository(TransacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Adicionar(Transacao transacao)
        {
            _dbContext.Transacoes.Add(transacao);
            _dbContext.SaveChanges();
        }
    }

}
