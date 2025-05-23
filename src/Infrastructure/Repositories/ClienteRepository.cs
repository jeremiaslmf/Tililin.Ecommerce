using Microsoft.EntityFrameworkCore;
using Tililin.Domain.Entities;
using Tililin.Domain.Repositories;
using Tililin.Infrastructure.Data.Context;
using Tililin.Infrastructure.Repositories.Base;

namespace Tililin.Infrastructure.Repositories;

public class ClienteRepository(TililinDbContext context) : RepositoryBase<Cliente>(context), IClienteRepository
{
    public async Task<Guid?> EmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        return (await _set.FirstOrDefaultAsync(x => x.Contato.Email.Valor == email, cancellationToken))?.PublicId;
    }

    public async Task<Guid?> CpfExistsAsync(string cpf, CancellationToken cancellationToken = default)
    {
        return (await _set.FirstOrDefaultAsync(x => x.Cpf == cpf, cancellationToken))?.PublicId;
    }
}
