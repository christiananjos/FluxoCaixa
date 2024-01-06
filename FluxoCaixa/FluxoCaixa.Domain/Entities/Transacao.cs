using FluxoCaixa.Domain.Enums;

namespace FluxoCaixa.Domain.Entities
{
    public class Transacao : ModelBase
    {
        public Conta Conta { get; set; }
        public Guid ContaId { get; set; }

        public TipoTransacao TipoTransacao { get; set; }
        public int TipoTransacaoId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
