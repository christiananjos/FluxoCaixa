using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FluxoCaixa.Data.Repository
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Transacao>> GetFilter(TransacaoFilter transacao)
        {
            try
            {
                var transacoes = await dbSet
                    .Where(x => transacao.ContaId != null && x.ContaId == transacao.ContaId
                    && transacao.TipoTransacaoId != null && x.TipoTransacaoId == transacao.TipoTransacaoId
                    && transacao.CreateAt != null && x.CreateAt == transacao.CreateAt)
                    .ToListAsync();

                return transacoes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }

}
