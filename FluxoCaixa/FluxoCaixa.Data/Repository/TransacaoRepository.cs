using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;
using System.Data.Entity;

namespace FluxoCaixa.Data.Repository
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Transacao>> GetFilter(TransacaoFilter transacao)
        {
            return await dbSet.Where(x => x.ContaId == transacao.ContaId)
                .ToListAsync();
        }
    }

}
