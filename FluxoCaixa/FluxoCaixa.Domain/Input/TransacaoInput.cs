﻿namespace FluxoCaixa.Domain.Input
{
    public class TransacaoInput
    {
        public Guid ContaId { get; set; }
        public int TipoTransacaoId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
