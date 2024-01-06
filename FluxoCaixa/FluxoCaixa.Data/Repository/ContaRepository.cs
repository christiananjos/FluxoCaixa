using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Data.Repository
{
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        public ContaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task RemoveLogical(Conta conta)
        {
            await Update(conta);
        }
    }
}
