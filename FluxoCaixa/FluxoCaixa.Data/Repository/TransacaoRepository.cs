using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Data.Repository
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task RemoveLogical(Transacao transacao)
        {
            transacao.SetRemoveAtDate();
            await Update(transacao);
        }
    }

}
