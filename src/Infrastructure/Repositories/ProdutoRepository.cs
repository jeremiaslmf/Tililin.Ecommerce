using Tililin.Domain.Entities;
using Tililin.Domain.Repositories;
using Tililin.Infrastructure.Data.Context;
using Tililin.Infrastructure.Repositories.Base;

namespace Tililin.Infrastructure.Repositories;

public class ProdutoRepository(TililinDbContext context) : RepositoryBase<Produto>(context), IProdutoRepository
{
}
