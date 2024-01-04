using FluxoCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoCaixa.Data.Context.Configurations
{
    public class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(t => t.CreateAt)
                    .IsRequired()
                    .HasColumnType("Date")
                    .HasDefaultValueSql("GetDate()");
        }
    }
}
