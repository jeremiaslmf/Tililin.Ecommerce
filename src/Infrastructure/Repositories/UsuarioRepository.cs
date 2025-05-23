using Microsoft.EntityFrameworkCore;
using Tililin.Domain.Entities;
using Tililin.Domain.Repositories;
using Tililin.Infrastructure.Data.Context;
using Tililin.Infrastructure.Repositories.Base;

namespace Tililin.Infrastructure.Repositories;

public class UsuarioRepository(TililinDbContext context) : RepositoryBase<Usuario>(context), IUsuarioRepository
{
    public async Task<Usuario> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _set.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<Usuario> GetByNameAsync(string nome, CancellationToken cancellationToken = default)
    {
        return await _set.FirstOrDefaultAsync(u => u.Nome == nome, cancellationToken);
    }
}
