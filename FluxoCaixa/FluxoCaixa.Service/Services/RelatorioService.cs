using FluxoCaixa.Data;
using FluxoCaixa.Domain.Models;
using FluxoCaixa.Services.Interfaces;
using System.Data.Entity;

namespace FluxoCaixa.Services.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly Context _dbContext;

        public RelatorioService(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Transacao>> GerarRelatorio(int contaId, DateTime startDate, DateTime endDate)
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
