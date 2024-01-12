namespace FluxoCaixa.Domain.Input
{
    public class TransacaoFilter
    {
        public Guid? ContaId { get; set; }
        public Guid? TipoTransacaoId { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
