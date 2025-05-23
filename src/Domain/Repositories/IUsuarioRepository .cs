using Tililin.Domain.Entities;
using Tililin.Domain.Repositories.Base;

namespace Tililin.Domain.Repositories;

public interface IUsuarioRepository : IRepositoryBase<Usuario>
{
    Task<Usuario> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<Usuario> GetByNameAsync(string nome, CancellationToken cancellationToken = default);
}
