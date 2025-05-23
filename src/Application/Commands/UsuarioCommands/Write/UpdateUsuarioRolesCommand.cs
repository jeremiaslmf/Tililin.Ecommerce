using Tililin.Application.Commands.Base;
using Tililin.Domain.Enums;

namespace Tililin.Application.Commands.UsuarioCommands.Write;

public class UpdateUsuarioRolesCommand : CommandBase<bool>
{
    public Guid PublicId { get; set; }
    public UserRoleType[] Roles { get; set; }
}
