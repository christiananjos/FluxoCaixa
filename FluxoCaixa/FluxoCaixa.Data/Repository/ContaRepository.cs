using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Data.Repository
{
    public class ContaRepository : BaseRepository<Conta>
    {
        public ContaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
