using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Services.Interfaces;

namespace FluxoCaixa.Services.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IRabbitMQService _rabbitMQService;

        public ContaService(IContaRepository contaRepository, IRabbitMQService rabbitMQService)
        {
            _contaRepository = contaRepository;
            _rabbitMQService = rabbitMQService;
        }



        public async Task<decimal> ObterSaldo(int contaId)
        {
            var conta = await _contaRepository.GetById(contaId);
            return conta?.Saldo ?? 0;
        }

        public void AtualizarSaldo(int contaId, decimal valor)
        {
            var conta = _contaRepository.GetById(contaId).Result;
            
            if (conta != null)
            {
                conta.Saldo += valor;
                _contaRepository.Update(conta);

                // Publicar mensagem no RabbitMQ para informar sobre a atualização de saldo
                _rabbitMQService.PublicarMensagem($"Saldo atualizado para a conta {contaId}: {conta.Saldo}");
            }
        }
    }
}
