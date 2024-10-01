using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence.Configurations;

public class ItemInspecaoConfiguration : IEntityTypeConfiguration<ItemInspecao>
{
    public void Configure(EntityTypeBuilder<ItemInspecao> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Realizado)
            .IsRequired();

        builder.HasOne(x => x.TipoItemInspecao)
            .WithMany()
            .HasForeignKey(x => x.TipoItemInspecaoId);

        builder.HasOne(x => x.Inspecao)
            .WithMany(x => x.Itens)
            .HasForeignKey(x => x.InspecaoId);
    }
}
