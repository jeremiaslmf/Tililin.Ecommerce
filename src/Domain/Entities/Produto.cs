using Tililin.Domain.Enums;

namespace Tililin.Domain.Entities;

public class Produto : EntityBase
{
    public string Nome { get; private set; }
    public string Codigo { get; private set; }
    public string Referencia { get; private set; }
    public string Descricao { get; private set; }
    public TamanhoProduto Tamanho { get; private set; }
    public decimal ValorCusto { get; private set; }
    public decimal ValorVenda { get; private set; }
    public double MargemLucro { get; private set; }
    public int QuantidadeEstoque { get; private set; }
    public bool Ativo { get; private set; }

    public static Produto New(string nome, string codigo, decimal preco, int quantidadeEstoque, string descricao = null) => new()
    {
        Nome = nome,
        Codigo = codigo,
        ValorVenda = preco,
        QuantidadeEstoque = quantidadeEstoque,
        Descricao = descricao?.Trim(),
        Ativo = true,
    };

    public void Ativar()
    {
        Ativo = true;
        SetUpdated();
    }

    public void Desativar()
    {
        Ativo = false;
        SetUpdated();
    }

    public void AtualizarEstoque(int novaQuantidade)
    {
        if (novaQuantidade < 0)
            throw new ArgumentException("Quantidade em estoque não pode ser negativa.");

        QuantidadeEstoque = novaQuantidade;
        SetUpdated();
    }

    public void AtualizarPreco(decimal novoPreco)
    {
        if (novoPreco <= 0)
            throw new ArgumentException("O preço deve ser maior que zero.");

        ValorVenda = novoPreco;
        SetUpdated();
    }

    public void AtualizarDescricao(string descricao)
    {
        Descricao = descricao?.Trim();
        SetUpdated();
    }
}
