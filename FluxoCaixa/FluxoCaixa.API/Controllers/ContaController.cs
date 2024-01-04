using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaApplication _contaApplication;
        public ContaController(IContaApplication contaApplication)
        {
            _contaApplication = contaApplication;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Conta>>> Get()
        {
            return await _contaApplication.GetAll();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Conta>> GetById(Guid id)
        {
            return await _contaApplication.GetById(id);
        }

        [HttpPost()]
        public async Task<ActionResult<Conta>> Create(Conta conta)
        {
            return await _contaApplication.Add(conta);
        }

        [HttpPut()]
        public async Task<ActionResult<Conta>> Update(Conta conta)
        {
            return await _contaApplication.Update(conta);
        }

        [HttpDelete()]
        public async Task Delete(Guid id)
        {
            await _contaApplication.Remove(id);
        }
    }
}
