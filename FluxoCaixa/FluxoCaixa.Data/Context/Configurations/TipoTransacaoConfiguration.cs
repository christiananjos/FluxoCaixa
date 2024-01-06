using FluxoCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoCaixa.Data.Context.Configurations
{
    public class TipoTransacaoConfiguration : IEntityTypeConfiguration<TipoTransacao>
    {
        public void Configure(EntityTypeBuilder<TipoTransacao> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Descricao)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
