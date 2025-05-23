using FluentValidation;
using Tililin.Application.Commands.FornecedorCommands;

namespace Tililin.Application.Validators.Fornecedor;

public class CriarFornecedorCommandValidator : AbstractValidator<CriarFornecedorCommand>
{
    public CriarFornecedorCommandValidator()
    {
        RuleFor(x => x.RazaoSocial).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Cnpj).NotEmpty().Length(14);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Telefone).NotEmpty().MinimumLength(10);
        RuleFor(x => x.Cep).NotEmpty().Length(8);
        RuleFor(x => x.Logradouro).NotEmpty();
        RuleFor(x => x.Numero).NotEmpty();
        RuleFor(x => x.Bairro).NotEmpty();
        RuleFor(x => x.Cidade).NotEmpty();
        RuleFor(x => x.Estado).NotEmpty();
    }
}
