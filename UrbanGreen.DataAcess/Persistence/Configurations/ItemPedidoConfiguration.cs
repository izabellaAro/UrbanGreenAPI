using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence.Configurations;

internal class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
{
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
        builder.HasKey(ip => ip.Id);

        builder.Property(ip => ip.Quantidade)
            .HasDefaultValue(1)
            .IsRequired();

        builder.Property(ip => ip.ProdutoId)
            .IsRequired();

        builder.HasOne(ip => ip.Produto)
            .WithMany()
            .HasForeignKey(ip => ip.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict);

        //builder.HasOne(ip => ip.Pedido)
        //    .WithMany(p => p.ItemPedidos)
        //    .HasForeignKey(ip => ip.PedidoId)
        //    .OnDelete(DeleteBehavior.Cascade);
    }
}
