namespace FluxoCaixa.Domain.Entities
{
    public class Conta : ModelBase
    {
        public Conta(string nome, decimal saldo)
        {
            Nome = nome;
            Saldo = saldo;
        }
        public Conta()
        {
                
        }
        public string Nome { get; set; }
        public decimal Saldo { get; set; }
    }
}
