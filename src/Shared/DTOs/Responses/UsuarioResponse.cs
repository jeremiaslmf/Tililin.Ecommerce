using Tililin.Shared.DTOs.Responses.Base;

namespace Tililin.Shared.DTOs.Responses;

public class UsuarioResponse(Guid publicId) : ResposneBase(publicId)
{
    public string Nome { get; set; } = default!;
    public string Email { get; set; } = default!;

    public static UsuarioResponse Of(Guid publicId, string nome, string email) => new(publicId)
    {
        Nome = nome,
        Email = email
    };
}
