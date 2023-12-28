﻿namespace FluxoCaixa.Domain.Models
{
    public class Transacao : ModelBase
    {
        public int TransacaoId { get; set; }
        public int ContaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
