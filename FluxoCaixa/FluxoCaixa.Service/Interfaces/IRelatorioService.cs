using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Services.Interfaces
{
    public interface IRelatorioService
    {
        Task<List<Transacao>> GerarRelatorio(Guid contaId, DateTime startDate, DateTime endDate);
    }
}
