using FluxoCaixa.Data.Context;
using FluxoCaixa.Data.Interfaces;

namespace FluxoCaixa.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public IContaRepository Contas { get; }
        public ITransacaoRepository Transacoes { get; }

        public UnitOfWork(DbContext dbContext, IContaRepository contas, ITransacaoRepository transacoes)
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
