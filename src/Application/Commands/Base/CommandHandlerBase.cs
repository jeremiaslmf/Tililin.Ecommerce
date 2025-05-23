using Tililin.Domain.Repositories;

namespace Tililin.Application.Commands.Base;

public abstract class CommandHandlerBase<TRepository>(IUnitOfWork uow, TRepository repository) where TRepository : class
{
    protected readonly IUnitOfWork _uow = uow;
    protected readonly TRepository _repository = repository;
}
