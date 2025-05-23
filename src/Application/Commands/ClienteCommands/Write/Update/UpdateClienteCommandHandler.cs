using MediatR;
using Tililin.Application.Commands.Base;
using Tililin.Domain.Exceptions;
using Tililin.Domain.Repositories;
using Tililin.Domain.ValueObjects;
using Tililin.Shared.DTOs.Responses;

namespace Tililin.Application.Commands.ClienteCommands.Write.Update;

public class UpdateClienteCommandHandler(IUnitOfWork uow, IClienteRepository repository)
    : CommandHandlerBase<IClienteRepository>(uow, repository),
      IRequestHandler<UpdateClienteCommand, ClienteResponse>
{
    public async Task<ClienteResponse> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _repository.GetByPublicIdAsync(request.PublicId, cancellationToken);
        if (cliente == default)
            throw new BusinessException("Cliente não encontrado.");

        var clientPublicId = await _repository.EmailExistsAsync(request.Email, cancellationToken);
        if (!cliente.PublicId.Equals(clientPublicId))
            throw new BusinessException("Email já está em uso.");

        var contato = Contato.Of(new Email(request.Email), new Telefone(request.Telefone), request.Observacoes);
        var endereco = Endereco.Of(request.Logradouro, request.NomeLogradouro, request.Numero, request.Bairro, request.Cidade, request.Estado, request.Cep);
        cliente.Update(request.Nome, request.SobreNome, request.Idade, request.DataNascimento, contato, endereco);
        
        _repository.Update(cliente);
        await _uow.CommitAsync(cancellationToken);

        return ClienteResponse.Of(cliente);
    }
}
