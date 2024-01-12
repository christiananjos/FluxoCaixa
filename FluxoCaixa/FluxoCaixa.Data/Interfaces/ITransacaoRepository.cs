using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;
using System.Data.Entity.Infrastructure;

namespace FluxoCaixa.Data.Interfaces
{
    public interface ITransacaoRepository : IBaseRepository<Transacao>
    {
        Task<IEnumerable<Transacao>> GetFilter(TransacaoFilter transacao);
    }
}
