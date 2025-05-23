using Tililin.Application.Commands.Base;
using Tililin.Domain.Entities;
using Tililin.Shared.DTOs.Responses;
using Tililin.Shared.Extensions;

namespace Tililin.Application.Commands.ProdutoCommands;

public class CriarProdutoCommand : CommandBase<ProdutoResponse>
{
    public string Nome { get; init; } = default!;
    public string Codigo { get; init; } = default!;
    public decimal Preco { get; init; }
    public int QuantidadeEstoque { get; init; }
    public string Descricao { get; init; }

    public Produto ToEntity()
    {
        var produto = Produto.New(Nome, Codigo, Preco, QuantidadeEstoque, Descricao);
        produto.Sanitize();
        return produto;
    }
}
