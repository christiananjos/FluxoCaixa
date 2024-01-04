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
        public async Task<ActionResult<Transacao>> Add(Transacao entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<Transacao>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Transacao>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Transacao>> Update(Transacao entity)
        {
            throw new NotImplementedException();
        }
    }
}
