using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tililin.Domain.Entities;

namespace Tililin.Infrastructure.Data.Mappings;

public class ProdutoMapping : BaseMapping<Produto>
{
    protected ProdutoMapping() : base("Produtos")
    {
    }

    public new void Configure(EntityTypeBuilder<Produto> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.Referencia);
        builder.Property(p => p.QuantidadeEstoque);
        builder.Property(p => p.ValorVenda).HasPrecision(18, 2);
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Codigo).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Ativo).IsRequired().HasDefaultValue(true);
        builder.Property(p => p.Tamanho).IsRequired();

        builder.HasIndex(x => x.Nome);
        builder.HasIndex(x => x.Codigo);
        builder.HasIndex(x => x.Referencia);
    }
}
