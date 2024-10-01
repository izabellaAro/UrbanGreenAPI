using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence.Configurations;

public class TipoItemInspecaoConfiguration : IEntityTypeConfiguration<TipoItemInspecao>
{
    public void Configure(EntityTypeBuilder<TipoItemInspecao> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired();
    }
}
