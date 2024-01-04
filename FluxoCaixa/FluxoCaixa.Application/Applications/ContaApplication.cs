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
        public async Task<ActionResult<Conta>> Add(Conta entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<Conta>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Conta>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Conta>> Update(Conta entity)
        {
            throw new NotImplementedException();
        }
    }
}
