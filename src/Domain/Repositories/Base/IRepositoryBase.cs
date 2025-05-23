namespace Tililin.Domain.Repositories.Base;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task<T> GetByPublicIdAsync(Guid publicId, CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Remove(T entity);
}
