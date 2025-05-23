using MediatR;
using Tililin.Application.Commands.Base;
using Tililin.Application.Common.Hash;
using Tililin.Domain.Entities;
using Tililin.Domain.Exceptions;
using Tililin.Domain.Repositories;
using Tililin.Shared.DTOs.Responses;

namespace Tililin.Application.Commands.UsuarioCommands.Write;

public class RegisterUsuarioCommandHandler(IUnitOfWork uow, IUsuarioRepository repository, IAppPasswordHasher passwordHasher)
    : CommandHandlerBase<IUsuarioRepository>(uow, repository),
      IRequestHandler<CreateUsuarioCommand, UsuarioResponse>
{
    private readonly IAppPasswordHasher _passwordHasher = passwordHasher;

    public async Task<UsuarioResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var email = request.Email.Trim().ToLowerInvariant();
        var nome = request.Nome.Trim().ToLowerInvariant();

        if (await _repository.GetByEmailAsync(email, cancellationToken) is not null)
            throw new BusinessException("E-mail já cadastrado.");

        if (await _repository.GetByNameAsync(nome, cancellationToken) is not null)
            throw new BusinessException("Nome para login já cadastrado.");

        var senhaHash = _passwordHasher.Hash(request.Senha);

        var usuario = Usuario.New(request.Nome, email, senhaHash, request.Roles);

        await _repository.AddAsync(usuario, cancellationToken);
        await _uow.CommitAsync(cancellationToken);

        return UsuarioResponse.Of(usuario.PublicId, usuario.Nome, usuario.Email);
    }
}
