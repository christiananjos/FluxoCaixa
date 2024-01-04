using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoApplication _transacaoApplication;

        public TransacaoController(ITransacaoApplication transacaoApplication)
        {
            _transacaoApplication = transacaoApplication;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Transacao>>> Get()
        {
            return await _transacaoApplication.GetAll();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Transacao>> GetById(Guid id)
        {
            return await _transacaoApplication.GetById(id);
        }

        [HttpPost()]
        public async Task<ActionResult<Transacao>> Create(Transacao transacao)
        {
            return await _transacaoApplication.Add(transacao);
        }

        [HttpPut()]
        public async Task<ActionResult<Transacao>> Update(Transacao transacao)
        {
            return await _transacaoApplication.Update(transacao);
        }

        [HttpDelete()]
        public async Task Delete(Guid id)
        {
            await _transacaoApplication.Remove(id);
        }
    }
}
