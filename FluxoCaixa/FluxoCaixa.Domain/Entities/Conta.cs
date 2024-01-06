namespace FluxoCaixa.Domain.Entities
{
    public class Conta : ModelBase
    {
        public string Nome { get; set; }
        public decimal Saldo { get; set; }
    }
}
