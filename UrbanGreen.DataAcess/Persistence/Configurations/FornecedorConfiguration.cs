using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence.Configurations;

public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
{ 
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.HasKey(x => x.FornecedorId);
        builder.Property(x => x.Nome)
           .IsRequired();
    }
}

