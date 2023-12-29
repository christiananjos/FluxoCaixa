using FluxoCaixa.Domain.Models;

namespace FluxoCaixa.Services.Interfaces
{
    public interface IRelatorioService
    {
        Task<List<Transacao>> GerarRelatorio(int contaId, DateTime startDate, DateTime endDate);
    }
}
