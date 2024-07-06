using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence.Configurations;

public class PessoaJuridicaConfiguration : IEntityTypeConfiguration<PessoaJuridica>
{
    public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeFantasia)
            .IsRequired();

        builder.Property(x => x.CNPJ)
            .IsRequired()
            .HasMaxLength(14);

        builder.Property(x => x.RazaoSocial)
            .IsRequired();

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Telefone)
            .IsRequired()
            .HasMaxLength(15);
    }
}
