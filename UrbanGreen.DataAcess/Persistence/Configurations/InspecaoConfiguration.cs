using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence.Configurations;

internal class InspecaoConfiguration : IEntityTypeConfiguration<Inspecao>
{
    public void Configure(EntityTypeBuilder<Inspecao> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Data)
            .IsRequired();

        builder.HasOne(x => x.Produto)
            .WithOne(x => x.Inspecao)
            .HasForeignKey<Inspecao>(x => x.ProdutoId);

        //builder.Property(x => x.SelecaoSemente)
        //    .IsRequired();

        //builder.Property(x => x.ControlePragas)
        //    .IsRequired();

        //builder.Property(x => x.Irrigacao)
        //    .IsRequired();

        //builder.Property(x => x.CuidadoSolo)
        //    .IsRequired();

        //builder.Property(x => x.Colheita)
        //    .IsRequired();
    }
}
