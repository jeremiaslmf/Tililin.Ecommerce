using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tililin.Domain.Entities;

namespace Tililin.Infrastructure.Data.Mappings;

public class ClienteMapping : BaseMapping<Cliente>
{
    protected ClienteMapping() : base("Clientes")
    {
    }

    public override void Configure(EntityTypeBuilder<Cliente> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.Cpf).IsRequired().HasMaxLength(11);
        builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
        builder.Property(c => c.SobreNome).IsRequired().HasMaxLength(100);
        builder.Property(c => c.DataNascimento).IsRequired();
        builder.Property(c => c.Idade).IsRequired();

        builder.OwnsOne(c => c.Contato, contato =>
        {
            contato.OwnsOne(x => x.Email, email =>
            {
                email.Property(e => e.Valor).HasColumnName("Email").HasMaxLength(150).IsRequired();
            });
            contato.OwnsOne(x => x.Telefone, fone =>
            {
                fone.Property(t => t.Numero).HasColumnName("Telefone").HasMaxLength(20).IsRequired();
            });
            contato.Property(x => x.Observacoes).HasMaxLength(500);
        })
        .Navigation(c => c.Contato).IsRequired();

        builder.OwnsOne(c => c.Endereco, endereco =>
        {
            endereco.Property(e => e.Logradouro).HasMaxLength(100).IsRequired();
            endereco.Property(e => e.Numero).HasMaxLength(10).IsRequired();
            endereco.Property(e => e.Bairro).HasMaxLength(60).IsRequired();
            endereco.Property(e => e.Cidade).HasMaxLength(60).IsRequired();
            endereco.Property(e => e.Estado).HasMaxLength(2).IsRequired();
            endereco.Property(e => e.CEP).HasMaxLength(8).IsRequired();
        });

        builder.HasIndex(c => c.Cpf).IsUnique();
        builder.HasIndex(c => c.Nome).IsUnique();
    }
}
