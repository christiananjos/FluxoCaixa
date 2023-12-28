using FluxoCaixa.Data.Interfaces;

namespace FluxoCaixa.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _dbContext;
        public IContaRepository Contas { get; }
        public ITransacaoRepository Transacoes { get; }

        public UnitOfWork(Context dbContext, IContaRepository contas, ITransacaoRepository transacoes)
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
