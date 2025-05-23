using Microsoft.EntityFrameworkCore;
using Tililin.Domain;
using Tililin.Domain.Repositories.Base;
using Tililin.Infrastructure.Data.Context;

namespace Tililin.Infrastructure.Repositories.Base;

public abstract class RepositoryBase<T>(TililinDbContext context) : IRepositoryBase<T> where T : EntityBase
{
    protected readonly TililinDbContext _context = context;
    protected readonly DbSet<T> _set = context.Set<T>();

    public async Task<T> GetByPublicIdAsync(Guid publicId, CancellationToken cancellationToken = default)
    {
        return await _set.FirstOrDefaultAsync(x => x.PublicId == publicId, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _set.AddAsync(entity, cancellationToken);
    }

    public void Remove(T entity)
    {
        entity.Disable();
        Update(entity);
    }

    public void Update(T entity)
    {
        _set.Update(entity);
    }
}