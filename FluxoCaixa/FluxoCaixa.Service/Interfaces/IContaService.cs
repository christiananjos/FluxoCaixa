namespace FluxoCaixa.Services.Interfaces
{
    public interface IContaService
    {
        Task<decimal> ObterSaldo(int contaId);
        void AtualizarSaldo(int contaId, decimal valor);
    }
}
