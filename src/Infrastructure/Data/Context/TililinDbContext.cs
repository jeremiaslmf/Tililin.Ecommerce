using Microsoft.EntityFrameworkCore;
using Tililin.Domain.Entities;

namespace Tililin.Infrastructure.Data.Context;

public class TililinDbContext : DbContext
{
    public TililinDbContext(DbContextOptions<TililinDbContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TililinDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
