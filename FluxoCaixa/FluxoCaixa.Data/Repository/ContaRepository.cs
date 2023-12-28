using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Models;

namespace FluxoCaixa.Data.Repository
{
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        public ContaRepository(Context dbContext) : base(dbContext)
        {

        }


    }
}
