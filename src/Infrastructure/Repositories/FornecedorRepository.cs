using Tililin.Domain.Entities;
using Tililin.Domain.Repositories;
using Tililin.Infrastructure.Data.Context;
using Tililin.Infrastructure.Repositories.Base;

namespace Tililin.Infrastructure.Repositories;

public class FornecedorRepository(TililinDbContext context) : RepositoryBase<Fornecedor>(context), IFornecedorRepository
{
}
