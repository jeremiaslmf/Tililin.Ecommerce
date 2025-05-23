using FluentValidation;
using Tililin.Application.Commands.ClienteCommands.Write;

namespace Tililin.Application.Validators.Cliente
{
    public abstract class CreateUpdateClienteCommandValidatorBase<T> : AbstractValidator<T> where T : ClienteCommandBase
    {
        protected CreateUpdateClienteCommandValidatorBase()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório")
                .MinimumLength(3)
                .WithMessage("Nome deve ter pelo menos 3 caracteres");

            RuleFor(x => x.SobreNome)
                .NotEmpty()
                .WithMessage("Sobrenome é obrigatório");

            RuleFor(x => x.Idade)
                .NotEmpty()
                .WithMessage("Idade é obrigatória");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email é obrigatório")
                .EmailAddress();

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage("Telefone é obrigatório")
                .MinimumLength(10);

            RuleFor(x => x.Cep)
                .NotEmpty()
                .WithMessage("CEP é obrigatório")
                .Length(8);

            RuleFor(x => x.Logradouro)
                .NotEmpty()
                .WithMessage("Logradouro é obrigatório");

            RuleFor(x => x.Numero)
                .NotEmpty()
                .WithMessage("Número é obrigatório");

            RuleFor(x => x.Bairro)
                .NotEmpty()
                .WithMessage("Bairro é obrigatório");

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .WithMessage("Cidade é obrigatória");

            RuleFor(x => x.Estado)
                .NotEmpty()
                .WithMessage("Estado é obrigatório");
        }
    }
}

