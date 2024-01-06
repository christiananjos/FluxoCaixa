using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Data.Repository;
using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Application.Applications
{
    public class TransacaoApplication : ITransacaoApplication
    {
        private readonly ITransacaoRepository _transacaoRepository;
        public TransacaoApplication(ITransacaoRepository transacaoRepository) => _transacaoRepository = transacaoRepository;
        public async Task<ActionResult<Transacao>> Add(Transacao entity)
        {
            //Regras:
            //Ao criar uma Transação irá atualizaar o saldo da conta.

            //Ao finalizar enviar mensagem RabbitMq
            entity.SetCreateAtDate();
            return await _transacaoRepository.Add(entity);
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

                transacaoUpdated =  await _transacaoRepository.Update(transacao);
            }

            return transacaoUpdated;

           
        }
    }
}
