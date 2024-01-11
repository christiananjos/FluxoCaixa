namespace FluxoCaixa.Domain.Entities
{
    public class TipoTransacao : ModelBase
    {
        public TipoTransacao(int idInterno, string descricao)
        {
            IdInterno = idInterno;
            Descricao = descricao;
        }

        public TipoTransacao()
        {
        }

        public int IdInterno { get; set; }
        public string Descricao { get; set; }
    }
}
