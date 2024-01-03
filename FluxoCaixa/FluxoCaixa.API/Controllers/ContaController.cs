using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : Controller
    {
        private readonly IContaApplication _contaApplication;

        public ContaController(IContaApplication contaApplication)
        {
            _contaApplication = contaApplication;
        }

        [HttpGet]
        public async Task<IEnumerable<Conta>> GetAll()
        {
            var contas = await _contaApplication.GetAll();
            return contas;
        }

        [HttpPost]
        public async Task<Conta> Create(Conta conta)
        {
            var contaCreated = await _contaApplication.Add(conta);
            return contaCreated;
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _contaApplication.Remove(id);
        }

        [HttpPut]
        public async Task Update(Conta conta)
        {
            await _contaApplication.Update(conta);
        }
    }
}
