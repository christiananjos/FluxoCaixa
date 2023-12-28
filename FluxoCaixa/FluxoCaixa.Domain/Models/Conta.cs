namespace FluxoCaixa.Domain.Models
{
    public class Conta : ModelBase
    {
        public int ContaId { get; set; }
        public decimal Saldo { get; set; }
    }
}
