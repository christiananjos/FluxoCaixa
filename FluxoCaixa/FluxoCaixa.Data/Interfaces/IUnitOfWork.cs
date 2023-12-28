namespace FluxoCaixa.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IContaRepository Contas { get; }
        ITransacaoRepository Transacoes { get; }

        int Save();
    }
}
