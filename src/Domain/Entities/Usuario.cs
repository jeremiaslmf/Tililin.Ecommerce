using System.ComponentModel.DataAnnotations.Schema;
using Tililin.Domain.Enums;

namespace Tililin.Domain.Entities;

public class Usuario : EntityBase
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool Ativo { get; private set; }
    public string Roles { get; private set; }

    [NotMapped]
    public List<string> RoleList
    {
        get => Roles?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList() ?? [];
        set => Roles = string.Join(',', value);
    }

    public static Usuario New(string nome, string email, string senhaHash, UserRoleType[] roles) => new()
    {
        Nome = nome,
        Email = email,
        PasswordHash = senhaHash,
        Ativo = true,
        Roles = BuildRoles(roles),
    };

    public void Inativar() => Ativo = false;

    public void AlterarSenha(string novaSenhaHash)
    {
        PasswordHash = novaSenhaHash;
    }

    public void AtualizarPermissoes(UserRoleType[] roles)
    {
        Roles = BuildRoles(roles);
    }

    private static string BuildRoles(UserRoleType[] roles)
    {
        return string.Join(", ", roles.Select(x => x.ToString()));
    }
}
