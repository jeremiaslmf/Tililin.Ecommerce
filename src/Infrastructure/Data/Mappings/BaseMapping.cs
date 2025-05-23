using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tililin.Domain;

namespace Tililin.Infrastructure.Data.Mappings;

public abstract class BaseMapping<T>(string nomeTabela) : IEntityTypeConfiguration<T> where T : EntityBase
{
    private readonly string _nomeTabela = nomeTabela;

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        if (!string.IsNullOrEmpty(_nomeTabela))
            builder.ToTable(_nomeTabela);

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Disabled);
        builder.Property(p => p.PublicId).IsRequired();
        builder.Property(c => c.DataCriacao).IsRequired();
        builder.Property(c => c.AtualizadoEm);
    }
}
