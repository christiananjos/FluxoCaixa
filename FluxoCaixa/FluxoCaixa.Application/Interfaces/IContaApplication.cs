using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Application.Interfaces
{
    public interface IContaApplication : IBaseApplication<Conta>
    {
        Task<ActionResult<Conta>> AtualizaSaldo(Guid contaId, decimal valor);
    }
}
