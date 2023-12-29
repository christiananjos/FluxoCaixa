namespace FluxoCaixa.Services.Interfaces
{
    public interface ITransacaoService
    {
        Task RealizarTransacao(Guid contaId, decimal valor);
    }
}
