using Tililin.Domain.Entities;
using Tililin.Domain.Repositories.Base;

namespace Tililin.Domain.Repositories;

public interface IClienteRepository : IRepositoryBase<Cliente>
{
    Task<Guid?> CpfExistsAsync(string cpf, CancellationToken cancellationToken = default);
    Task<Guid?> EmailExistsAsync(string email, CancellationToken cancellationToken = default);
}
