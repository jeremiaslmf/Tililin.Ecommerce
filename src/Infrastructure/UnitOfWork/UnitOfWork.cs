using Tililin.Domain.Repositories;
using Tililin.Infrastructure.Data.Context;

namespace Tililin.Infrastructure.UnitOfWork;

public class UnitOfWork(TililinDbContext context) : IUnitOfWork
{
    private readonly TililinDbContext _context = context;

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
