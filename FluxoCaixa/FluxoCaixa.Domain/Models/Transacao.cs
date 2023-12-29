namespace FluxoCaixa.Domain.Models
{
    public class Transacao : ModelBase
    {
        public Conta Conta { get; set; }
        public Guid ContaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
