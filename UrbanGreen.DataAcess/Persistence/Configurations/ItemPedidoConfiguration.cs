using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence.Configurations
{
    internal class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.Property(x => x.Quantidade)
                .HasDefaultValue(1)
                .IsRequired();
        }
    }
}
