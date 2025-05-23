using MediatR;
using Tililin.Application.Queries.Clientes;
using Tililin.Domain.Exceptions;
using Tililin.Domain.Repositories;
using Tililin.Shared.DTOs.Responses;

namespace Tililin.Application.Commands.ClienteCommands.Read;

public class GetClienteByIdCommandHandler(IClienteRepository repository) 
    : IRequestHandler<GetClienteByIdQuery, ClienteResponse>
{
    private readonly IClienteRepository _repository = repository;

    public async Task<ClienteResponse> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
    {
        var cliente = await _repository.GetByPublicIdAsync(request.PublicId, cancellationToken);

        if (cliente == default)
            throw new NotFoundException("Cliente não encontrado.");

        return ClienteResponse.Of(cliente);
    }
}
