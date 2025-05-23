using Tililin.Domain.Entities;

namespace Tililin.Shared.DTOs.Responses;

public class UsuarioLoginResponse
{
    public string Token { get; set; } = default!;
    public UsuarioResponse Usuario { get; set; } = default!;

    public static UsuarioLoginResponse Of(string token, Usuario usuario) => new()
    {
        Token = token,
        Usuario = UsuarioResponse.Of(usuario.PublicId, usuario.Nome, usuario.Email)
    };
}
