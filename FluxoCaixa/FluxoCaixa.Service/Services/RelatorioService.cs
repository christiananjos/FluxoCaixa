using FluxoCaixa.Data;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Interfaces;
using FluxoCaixa.Services.Interfaces;
using System.Data.Entity;

namespace FluxoCaixa.Services.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly FluxoContext _dbContext;
        public IUnitOfWork _unitOfWork;

        public RelatorioService(FluxoContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Transacao>> GerarRelatorio(Guid contaId, DateTime startDate, DateTime endDate)
        {
            var transacoes = await _dbContext.Transacoes
                .Where(t => t.ContaId == contaId && t.Data >= startDate && t.Data <= endDate)
                .ToListAsync();

            // Lógica para gerar um relatório com base nas transações
            // ...

            return transacoes;
        }
    }
}
