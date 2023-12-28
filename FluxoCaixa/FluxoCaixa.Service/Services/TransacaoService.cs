using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Models;
using FluxoCaixa.Services.Interfaces;

namespace FluxoCaixa.Services.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly ContaService _contaService;

        public TransacaoService(ITransacaoRepository transacaoRepository, ContaService contaService)
        {
            _transacaoRepository = transacaoRepository;
            _contaService = contaService;
        }

        public void RealizarTransacao(int contaId, decimal valor)
        {
            var transacao = new Transacao
            {
                ContaId = contaId,
                Valor = valor,
                Data = DateTime.Now
            };

            _transacaoRepository.Adicionar(transacao);
            _contaService.AtualizarSaldo(contaId, valor);
        }
    }
}
