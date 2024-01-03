using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Application.Applications
{
    public class TransacaoApplication : BaseApplication<Transacao>
    {
        public TransacaoApplication(IUnitOfWork unitOfWork, IBaseRepository<Transacao> repository) : base(unitOfWork, repository)
        {
        }
    }
}
