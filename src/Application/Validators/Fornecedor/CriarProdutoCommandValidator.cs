using FluentValidation;
using Tililin.Application.Commands.ProdutoCommands;

namespace Tililin.Application.Validators.Fornecedor;

public class CriarProdutoCommandValidator : AbstractValidator<CriarProdutoCommand>
{
    public CriarProdutoCommandValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Codigo).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Preco).GreaterThan(0);
        RuleFor(x => x.QuantidadeEstoque).GreaterThanOrEqualTo(0);
    }
}
