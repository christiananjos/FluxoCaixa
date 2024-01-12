using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Application.Interfaces
{
    public interface ITransacaoApplication : IBaseApplication<Transacao>
    {
        Task<ActionResult<IEnumerable<Transacao>>> GetFilter(Guid? contaId, Guid? tipoTransacaoId, DateTime? createAt);
        byte[] GetStatement(Guid? contaId, Guid? tipoTransacaoId, DateTime? createAt);
    }
}
