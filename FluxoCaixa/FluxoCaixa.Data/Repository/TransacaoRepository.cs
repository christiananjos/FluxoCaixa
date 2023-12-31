﻿using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Data.Repository
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

}
