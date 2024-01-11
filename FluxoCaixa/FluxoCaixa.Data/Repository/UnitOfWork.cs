using FluxoCaixa.Data.Context;
using FluxoCaixa.Data.Interfaces;

namespace FluxoCaixa.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FluxoContext _dbContext;
        private bool _disposed = false;

        //public IContaRepository Contas { get; }
        //public ITransacaoRepository Transacoes { get; }

        public UnitOfWork(FluxoContext dbContext) => _dbContext = dbContext;

        public FluxoContext Context => _dbContext;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                _disposed = true;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
            Dispose();
        }
    }
}
