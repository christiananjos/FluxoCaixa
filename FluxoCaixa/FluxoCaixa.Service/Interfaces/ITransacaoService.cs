namespace FluxoCaixa.Services.Interfaces
{
    public interface ITransacaoService
    {
        Task RealizarTransacao(int contaId, decimal valor);
    }
}
