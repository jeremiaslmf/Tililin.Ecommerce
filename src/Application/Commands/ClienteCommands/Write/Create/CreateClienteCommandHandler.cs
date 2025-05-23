using MediatR;
using Tililin.Application.Commands.Base;
using Tililin.Domain.Exceptions;
using Tililin.Domain.Repositories;
using Tililin.Shared.DTOs.Responses;

namespace Tililin.Application.Commands.ClienteCommands.Write.Create;

public class CreateClienteCommandHandler(IUnitOfWork uow, IClienteRepository repository) 
    : CommandHandlerBase<IClienteRepository>(uow, repository), 
      IRequestHandler<CreateClienteCommand, ClienteResponse>
{
    public async Task<ClienteResponse> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        if ((await _repository.EmailExistsAsync(request.Email, cancellationToken)).HasValue)
            throw new BusinessException("Email já está em uso.");

        if ((await _repository.CpfExistsAsync(request.Cpf, cancellationToken)).HasValue)
            throw new BusinessException("CPF já cadastrado.");

        var cliente = request.ToEntity();
        await _repository.AddAsync(cliente, cancellationToken);
        await _uow.CommitAsync(cancellationToken);

        return ClienteResponse.Of(cliente);
    }
}
