using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;

namespace FluxoCaixa.Data.Interfaces
{
    public interface ITransacaoRepository : IBaseRepository<Transacao>
    {
        Task<IEnumerable<Transacao>> GetFilter(TransacaoFilter transacao);
    }
}
