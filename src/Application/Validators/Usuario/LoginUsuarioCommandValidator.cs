using FluentValidation;
using Tililin.Application.Commands.UsuarioCommands.Write;

namespace Tililin.Application.Validators.Usuario;

public class LoginUsuarioCommandValidator : AbstractValidator<LoginUsuarioCommand>
{
    public LoginUsuarioCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
                .WithMessage("O e-mail é obrigatório.")
            .EmailAddress()
                .WithMessage("Formato de e-mail inválido.");

        RuleFor(x => x.Password)
            .NotEmpty()
                .WithMessage("A senha é obrigatória.")
            .MinimumLength(6)
                .WithMessage("A senha deve ter pelo menos 6 caracteres.");
    }
}
