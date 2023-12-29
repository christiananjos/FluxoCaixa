﻿using FluxoCaixa.Domain.Models;
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
                .HasForeignKey(x => x.ContaId);
            
            builder.Property(t => t.CreateAt)
                    .IsRequired()
                    .HasColumnType("Date")
                    .HasDefaultValueSql("GetDate())");
        }
    }
}