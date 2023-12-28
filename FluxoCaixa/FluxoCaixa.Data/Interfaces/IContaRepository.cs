using FluxoCaixa.Domain.Models;

namespace FluxoCaixa.Data.Interfaces
{
    public interface IContaRepository
    {
        Conta ObterPorId(int contaId);
        void Atualizar(Conta conta);
    }
}
