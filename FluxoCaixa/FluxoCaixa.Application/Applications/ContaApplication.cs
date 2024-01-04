using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Application.Applications
{
    public class ContaApplication : IContaApplication
    {
        public ContaApplication()
        {
                
        }
        public Task<ActionResult<Conta>> Add(Conta entity)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Conta>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Conta>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Conta>> Update(Conta entity)
        {
            throw new NotImplementedException();
        }
    }
}
