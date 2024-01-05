﻿using AutoMapper;
using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FluxoCaixa.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaApplication _contaApplication;
        private readonly IMapper _mapper;
        public ContaController(IContaApplication contaApplication, IMapper mapper)
        {
            _contaApplication = contaApplication;
            _mapper = mapper;
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
        public async Task<ActionResult<Conta>> Create(ContaCreate conta)
        {
            var map = _mapper.Map<Conta>(conta);
            return await _contaApplication.Add(map);
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
