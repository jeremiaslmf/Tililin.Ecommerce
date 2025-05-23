using FluentValidation;
using Tililin.Application.Commands.UsuarioCommands.Write;
using Tililin.Domain.Enums;

namespace Tililin.Application.Validators.Usuario;

public class UpdateUsuarioRolesCommandValidator : AbstractValidator<UpdateUsuarioRolesCommand>
{
    public UpdateUsuarioRolesCommandValidator()
    {
        RuleFor(x => x.PublicId)
            .NotEmpty()
            .WithMessage("Id do usuário é obrigatório");

        RuleFor(x => x.Roles)
             .NotNull()
                .WithMessage("É necessário informar pelo menos um perfil.")
             .Must(roles => roles.Length > 0)
                .WithMessage("É necessário informar pelo menos um perfil.")
             .Must(roles => roles.All(r => Enum.IsDefined(typeof(UserRoleType), r)))
                .WithMessage("Perfil de usuário inválido.");
    }
}
