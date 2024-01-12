using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Application.Interfaces
{
    public interface ITransacaoApplication : IBaseApplication<Transacao>
    {
        Task<ActionResult<IEnumerable<Transacao>>> GetFilter(Guid? contaId, Guid? tipoTransacaoId, DateTime? createAt);
    }
}
