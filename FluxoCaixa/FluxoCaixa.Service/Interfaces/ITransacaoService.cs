namespace FluxoCaixa.Services.Interfaces
{
    public interface ITransacaoService
    {
        void RealizarTransacao(int contaId, decimal valor);
    }
}
