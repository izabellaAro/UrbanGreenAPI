using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
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

        builder.Property(x => x.Imagem);
    }
}