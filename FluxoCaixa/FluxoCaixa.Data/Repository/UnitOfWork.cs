using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Interfaces;

namespace FluxoCaixa.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FluxoContext _dbContext;
        public IContaRepository Contas { get; }
        public ITransacaoRepository Transacoes { get; }

        public UnitOfWork(FluxoContext dbContext, IContaRepository contas, ITransacaoRepository transacoes)
        {
            _dbContext = dbContext;
            Contas = contas;
            Transacoes = transacoes;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
