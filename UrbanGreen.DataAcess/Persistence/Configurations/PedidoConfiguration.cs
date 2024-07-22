using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Data)
            .IsRequired();

        //builder.HasMany(p => p.ItemPedidos)
        //        .WithOne(ip => ip.Pedido)
        //        .HasForeignKey(ip => ip.Id)
        //        .OnDelete(DeleteBehavior.Cascade);
    }
}
