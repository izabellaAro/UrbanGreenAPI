using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanGreenAPI.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence.Configurations;

public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired();

        builder.Property(x => x.Quantidade)
            .HasMaxLength(5000)
            .IsRequired();

        builder.Property(x => x.Valor)
            .HasMaxLength(10000)
            .IsRequired();
    }
}
