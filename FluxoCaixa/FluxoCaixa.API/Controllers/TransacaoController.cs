using AutoMapper;
using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Graphics;
using System;

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

        [HttpGet("GetStatement")]
        public async Task<ActionResult> GetStatement(Guid? contaId, Guid? tipoTransacaoId, DateTime? createAt)
        {
            var pdf = await _transacaoApplication.GetStatement(contaId, tipoTransacaoId, createAt);

            var dataStream = new MemoryStream(pdf);

            string fileName = "extrato" + DateTime.Now.Date.ToString("d") + ".pdf";
            return File(dataStream, "application/pdf", fileName);
        }


    }
}
