using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tililin.Domain.Entities;

namespace Tililin.Infrastructure.Data.Mappings;

public class FornecedorMapping : BaseMapping<Fornecedor>
{
    protected FornecedorMapping() : base("Fornecedores")
    {
    }

    public override void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        base.Configure(builder);

        builder.Property(f => f.Cnpj).IsRequired().HasMaxLength(14);
        builder.Property(f => f.Fantasia).IsRequired().HasMaxLength(150);
        builder.Property(f => f.RazaoSocial).IsRequired().HasMaxLength(120);

        builder.OwnsOne(f => f.Contato, contato =>
        {
            contato.OwnsOne(x => x.Email, email =>
            {
                email.Property(e => e.Valor).HasColumnName("Email").HasMaxLength(150).IsRequired();
            });
            contato.OwnsOne(x => x.Telefone, tel =>
            {
                tel.Property(t => t.Numero).HasColumnName("Telefone").HasMaxLength(20).IsRequired();
            });
            contato.Property(x => x.Observacoes).HasMaxLength(500);
        })
        .Navigation(c => c.Contato).IsRequired();

        builder.OwnsOne(f => f.Endereco, endereco =>
        {
            endereco.Property(e => e.Logradouro).HasMaxLength(100).IsRequired();
            endereco.Property(e => e.Numero).HasMaxLength(10).IsRequired();
            endereco.Property(e => e.Bairro).HasMaxLength(60).IsRequired();
            endereco.Property(e => e.Cidade).HasMaxLength(60).IsRequired();
            endereco.Property(e => e.Estado).HasMaxLength(2).IsRequired();
            endereco.Property(e => e.CEP).HasMaxLength(8).IsRequired();
        });

        builder.HasIndex(f => f.Cnpj).IsUnique();
        builder.HasIndex(f => f.Fantasia).IsUnique();
        builder.HasIndex(f => f.RazaoSocial).IsUnique();
    }
}


