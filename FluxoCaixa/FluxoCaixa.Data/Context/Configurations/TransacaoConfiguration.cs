﻿using FluxoCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoCaixa.Data.Context.Configurations
{
    public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.Conta)
                .WithMany()
                .HasForeignKey(x => x.ContaId)
                .IsRequired();

            builder.HasOne(x => x.TipoTransacao)
                 .WithMany()
                 .HasForeignKey(x => x.TipoTransacaoId)
                 .IsRequired();

            builder.Property(o => o.Descricao)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
