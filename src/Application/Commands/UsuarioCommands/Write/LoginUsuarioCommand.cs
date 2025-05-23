using Tililin.Application.Commands.Base;
using Tililin.Shared.DTOs.Responses;

namespace Tililin.Application.Commands.UsuarioCommands.Write;

public class LoginUsuarioCommand : CommandBase<UsuarioLoginResponse>
{
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
}
