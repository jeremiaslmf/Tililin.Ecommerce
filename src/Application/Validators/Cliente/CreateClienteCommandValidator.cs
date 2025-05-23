using FluentValidation;
using Tililin.Application.Commands.ClienteCommands.Write.Create;

namespace Tililin.Application.Validators.Cliente;

public class CreateClienteCommandValidator : CreateUpdateClienteCommandValidatorBase<CreateClienteCommand>
{
    public CreateClienteCommandValidator() : base()
    {
        RuleFor(x => x.Cpf)
              .NotEmpty()
              .WithMessage("CPF é obrigatório")
              .Length(11);
    }
}
