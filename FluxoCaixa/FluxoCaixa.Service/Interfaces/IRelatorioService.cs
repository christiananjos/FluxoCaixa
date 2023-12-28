namespace FluxoCaixa.Services.Interfaces
{
    public interface IRelatorioService
    {
        string GerarRelatorio(int contaId, DateTime startDate, DateTime endDate);
    }
}
