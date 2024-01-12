using AutoMapper;
using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoApplication _transacaoApplication;
        private readonly IMapper _mapper;

        public TransacaoController(ITransacaoApplication transacaoApplication, IMapper mapper)
        {
            _transacaoApplication = transacaoApplication;
            _mapper = mapper;
        }

        [HttpPost()]
        public async Task<ActionResult<Transacao>> Create(TransacaoInput transacao)
        {
            var map = _mapper.Map<Transacao>(transacao);
            return await _transacaoApplication.Add(map);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Transacao>>> Get()
        {
            return await _transacaoApplication.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Transacao>> GetById(Guid id)
        {
            return await _transacaoApplication.GetById(id);
        }


        [HttpGet("GetFilter")]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetFilter(Guid? contaId, Guid? tipoTransacaoId, DateTime? createAt)
        {
            return await _transacaoApplication.GetFilter(contaId, tipoTransacaoId, createAt);
        }


    }
}
