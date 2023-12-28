using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Models;

namespace FluxoCaixa.Data.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly ContaDbContext _dbContext;

        public ContaRepository(ContaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Conta ObterPorId(int contaId)
        {
            return _dbContext.Contas.FirstOrDefault(c => c.ContaId == contaId);
        }

        public void Atualizar(Conta conta)
        {
            _dbContext.Contas.Update(conta);
            _dbContext.SaveChanges();
        }
    }
}
