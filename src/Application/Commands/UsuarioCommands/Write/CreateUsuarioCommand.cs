using Tililin.Application.Commands.Base;
using Tililin.Domain.Enums;
using Tililin.Shared.DTOs.Responses;

namespace Tililin.Application.Commands.UsuarioCommands.Write;

public class CreateUsuarioCommand : CommandBase<UsuarioResponse>
{
    public string Nome { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
    public UserRoleType[] Roles { get; set; } = [ UserRoleType.User ];
}
