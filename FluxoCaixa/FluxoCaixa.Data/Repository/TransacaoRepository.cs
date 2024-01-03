using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Data.Repository
{
    public class TransacaoRepository : BaseRepository<Transacao>
    {
        public TransacaoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

}
