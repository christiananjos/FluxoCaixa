﻿using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Data.Interfaces
{
    public interface ITransacaoRepository : IBaseRepository<Transacao>
    {
        Task RemoveLogical(Transacao transacao);
    }
}
