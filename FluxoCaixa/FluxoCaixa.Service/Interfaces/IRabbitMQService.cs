namespace FluxoCaixa.Services.Interfaces
{
    public interface IRabbitMQService
    {
        void PublicarMensagem(string mensagem);
    }
}
