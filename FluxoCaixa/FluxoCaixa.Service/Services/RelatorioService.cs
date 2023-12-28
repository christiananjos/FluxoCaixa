using FluxoCaixa.Services.Interfaces;

namespace FluxoCaixa.Services.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly TransacaoDbContext _dbContext;

        public RelatorioService(TransacaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GerarRelatorio(int contaId, DateTime startDate, DateTime endDate)
        {
            var transacoes = _dbContext.Transacoes
                .Where(t => t.ContaId == contaId && t.Data >= startDate && t.Data <= endDate)
                .ToList();

            // Lógica para gerar um relatório com base nas transações
            // ...

            return "Relatório gerado com sucesso.";
        }
    }
}
