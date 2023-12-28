using FluxoCaixa.Domain.Models;

namespace FluxoCaixa.Data.Interfaces
{
    public interface ITransacaoRepository
    {
        void Adicionar(Transacao transacao);
    }
}
