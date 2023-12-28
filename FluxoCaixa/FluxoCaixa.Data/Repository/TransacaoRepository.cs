﻿using FluxoCaixa.Data.Context;
using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Models;

namespace FluxoCaixa.Data.Repository
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(DbContext dbContext) : base(dbContext)
        {

        }


    }

}
