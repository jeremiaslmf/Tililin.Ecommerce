using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tililin.Domain.Entities;

namespace Tililin.Infrastructure.Data.Mappings;

public class UsuarioMapping : BaseMapping<Usuario>
{
    protected UsuarioMapping() : base("Usuarios")
    {
    }

    public new void Configure(EntityTypeBuilder<Usuario> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Nome).IsRequired().HasMaxLength(120);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(180);
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.Ativo).IsRequired();
        builder.Property(u => u.Roles).IsRequired();

        builder.HasIndex(x => x.Nome);
        builder.HasIndex(x => x.Email);
    }
}
