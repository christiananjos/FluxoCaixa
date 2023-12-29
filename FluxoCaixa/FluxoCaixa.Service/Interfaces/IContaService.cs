namespace FluxoCaixa.Services.Interfaces
{
    public interface IContaService
    {
        Task<decimal> ObterSaldo(Guid contaId);
        void AtualizarSaldo(Guid contaId, decimal valor);
    }
}
