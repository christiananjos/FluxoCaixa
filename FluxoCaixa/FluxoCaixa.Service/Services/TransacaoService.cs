using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Data.Repository;
using FluxoCaixa.Domain.Models;
using FluxoCaixa.Services.Interfaces;
using System.Drawing;

namespace FluxoCaixa.Services.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly ContaService _contaService;
        public IUnitOfWork _unitOfWork;

        public TransacaoService(ITransacaoRepository transacaoRepository, ContaService contaService, IUnitOfWork unitOfWork)
        {
            _transacaoRepository = transacaoRepository;
            _contaService = contaService;
            _unitOfWork = unitOfWork;
        }

        public async Task RealizarTransacao(Guid contaId, decimal valor)
        {
            var transacao = new Transacao
            {
                ContaId = contaId,
                Valor = valor,
                Data = DateTime.Now
            };

            _unitOfWork.Transacoes.Add(transacao);
            _unitOfWork.Save();

            _contaService.AtualizarSaldo(contaId, valor);
        }
    }
}
