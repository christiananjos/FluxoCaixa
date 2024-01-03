using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Application.Applications
{
    public class ContaApplication : BaseApplication<Conta>
    {
        public ContaApplication(IUnitOfWork unitOfWork, IBaseRepository<Conta> repository) : base(unitOfWork, repository)
        {
        }
    }
}
