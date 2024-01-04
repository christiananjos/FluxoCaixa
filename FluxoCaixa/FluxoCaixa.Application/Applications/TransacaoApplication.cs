using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Application.Applications
{
    public class TransacaoApplication : ITransacaoApplication
    {
        public TransacaoApplication()
        {
                
        }
        public Task<ActionResult<Transacao>> Add(Transacao entity)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Transacao>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Transacao>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Transacao>> Update(Transacao entity)
        {
            throw new NotImplementedException();
        }
    }
}
