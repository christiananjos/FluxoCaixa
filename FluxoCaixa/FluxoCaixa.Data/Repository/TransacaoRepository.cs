using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data.Repository
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        protected DbSet<Transacao> dbSet;
        public TransacaoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            dbSet = _unitOfWork.Context.Set<Transacao>();
        }

        public async Task<IEnumerable<Transacao>> GetFilter(TransacaoFilter transacao)
        {
            var transacoes = await dbSet
                .Where(x => transacao.ContaId == null || x.ContaId == transacao.ContaId)
                .Where(x => transacao.TipoTransacaoId == null || x.TipoTransacaoId == transacao.TipoTransacaoId)
                .Where(x => transacao.CreateAt == null || x.CreateAt == transacao.CreateAt)
                .ToListAsync();

            return transacoes;
        }
    }

}
