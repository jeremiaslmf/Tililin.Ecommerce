using MediatR;
using Tililin.Application.Commands.Base;
using Tililin.Domain.Exceptions;
using Tililin.Domain.Repositories;

namespace Tililin.Application.Commands.UsuarioCommands.Write;

public class UpdateUsuarioRolesCommandHandler(IUnitOfWork uow, IUsuarioRepository repository)
    : CommandHandlerBase<IUsuarioRepository>(uow, repository),
      IRequestHandler<UpdateUsuarioRolesCommand, bool>
{
    public async Task<bool> Handle(UpdateUsuarioRolesCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _repository.GetByPublicIdAsync(request.PublicId, cancellationToken);
        if (usuario == default)
            throw new BusinessException("Usuário não encontrado.");

        usuario.AtualizarPermissoes(request.Roles);

        _repository.Update(usuario);
        await _uow.CommitAsync(cancellationToken);

        return true;
    }
}
