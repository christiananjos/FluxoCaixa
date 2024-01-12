﻿using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;
using FluxoCaixa.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FluxoCaixa.Application.Applications
{
    public class TransacaoApplication : ITransacaoApplication
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IContaApplication _contaApplication;
        private readonly IRabbitMQService _rabbitMQService;

        public TransacaoApplication(ITransacaoRepository transacaoRepository, IContaApplication contaApplication, IRabbitMQService rabbitMQService)
        {
            _transacaoRepository = transacaoRepository;
            _contaApplication = contaApplication;
            _rabbitMQService = rabbitMQService;
        }

        public async Task<ActionResult<Transacao>> Add(Transacao entity)
        {
            //Regras:
            //Criar uma Transação
            entity.SetCreateAtDate();
            var retornoTransacao = await _transacaoRepository.Add(entity);

            //Atualizar o saldo da conta.
            await _contaApplication.AtualizaSaldo(entity.ContaId, entity.Valor);

            //Ao finalizar enviar mensagem RabbitMQ com retornoTransacao
            _rabbitMQService.PublicarMensagem(JsonConvert.SerializeObject(retornoTransacao));

            return retornoTransacao;
        }

        public async Task<ActionResult<IEnumerable<Transacao>>> GetAll()
        {
            var transacoes = await _transacaoRepository.GetAll();

            return transacoes.ToList();
        }

        public async Task<ActionResult<Transacao>> GetById(Guid id)
        {
            return await _transacaoRepository.GetById(id);
        }

        public async Task<ActionResult<IEnumerable<Transacao>>> GetFilter(TransacaoFilter transacao)
        {
            var transacoes =  await _transacaoRepository.GetFilter(transacao);

            return transacoes.ToList();
           
        }

        public async Task Remove(Guid id)
        {
            var transacao = await _transacaoRepository.GetById(id);

            transacao.SetRemoveAtDate();

            await _transacaoRepository.Update(transacao);
        }

        public async Task<ActionResult<Transacao>> Update(Transacao entity)
        {
            Transacao transacaoUpdated = new();

            var transacao = await _transacaoRepository.GetById(entity.Id);

            if (transacao != null)
            {
                transacao.Valor = entity.Valor;
                transacao.SetRemoveAtDate();

                transacaoUpdated = await _transacaoRepository.Update(transacao);
            }

            return transacaoUpdated;


        }
    }
}
