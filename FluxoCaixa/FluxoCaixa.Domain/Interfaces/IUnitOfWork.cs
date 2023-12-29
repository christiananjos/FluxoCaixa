using FluxoCaixa.Data.Interfaces;

namespace FluxoCaixa.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IContaRepository Contas { get; }
        ITransacaoRepository Transacoes { get; }

        int Save();
    }
}
