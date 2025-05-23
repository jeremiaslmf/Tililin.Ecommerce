using FluentValidation;
using Tililin.Application.Commands.UsuarioCommands.Write;
using Tililin.Domain.Enums;

namespace Tililin.Application.Validators.Usuario;

public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
{
    public CreateUsuarioCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
                .WithMessage("O nome é obrigatório.")
            .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty()
                .WithMessage("O e-mail é obrigatório.")
            .EmailAddress()
                .WithMessage("Formato de e-mail inválido.");

        RuleFor(x => x.Senha)
            .NotEmpty()
                .WithMessage("A senha é obrigatória.")
            .MinimumLength(6)
                .WithMessage("A senha deve ter pelo menos 6 caracteres.");

        RuleFor(x => x.Roles)
            .NotNull()
                .WithMessage("É necessário informar pelo menos um perfil.")
            .Must(roles => roles.Length > 0)
                .WithMessage("É necessário informar pelo menos um perfil.")
            .Must(roles => roles.All(r => Enum.IsDefined(typeof(UserRoleType), r)))
                .WithMessage("Perfil de usuário inválido.");
    }
}
