using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Data.Repository
{
    public class TipoTransacaoRepository : BaseRepository<TipoTransacao>, ITipoTransacaoRepository
    {
        public TipoTransacaoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
