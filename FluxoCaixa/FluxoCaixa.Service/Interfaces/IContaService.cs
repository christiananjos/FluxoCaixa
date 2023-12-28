namespace FluxoCaixa.Services.Interfaces
{
    public interface IContaService
    {
        decimal ObterSaldo(int contaId);
        void AtualizarSaldo(int contaId, decimal valor);
    }
}
