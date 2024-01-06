using AutoMapper;
using FluxoCaixa.Application.Applications;
using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoTransacaoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITipoTransacaoApplication _tipoTransacaoApplication;

        public TipoTransacaoController(IMapper mapper, ITipoTransacaoApplication tipoTransacaoApplication)
        {
            _mapper = mapper;
            _tipoTransacaoApplication = tipoTransacaoApplication;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TipoTransacao>>> Get()
        {
            return await _tipoTransacaoApplication.GetAll();
        }

        [HttpGet("id")]
        public async Task<ActionResult<TipoTransacao>> GetById(Guid id)
        {
            return await _tipoTransacaoApplication.GetById(id);
        }

        [HttpPost()]
        public async Task<ActionResult<TipoTransacao>> Create(TipoTransacaoInput tipoTransacao)
        {
            var map = _mapper.Map<TipoTransacao>(tipoTransacao);

            return await _tipoTransacaoApplication.Add(map);
        }
    }
}
