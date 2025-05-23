using Tililin.Application.Commands.Base;
using Tililin.Domain.ValueObjects;
using Tililin.Shared.DTOs.Responses;
using Tililin.Shared.Extensions;
using FornecedorEntity = Tililin.Domain.Entities.Fornecedor;

namespace Tililin.Application.Commands.FornecedorCommands
{
    public class CriarFornecedorCommand : CommandBase<FornecedorResponse>
    {
        public string RazaoSocial { get; init; } = default!;
        public string Fantasia { get; init; } = default!;
        public string Cnpj { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string Telefone { get; init; } = default!;
        public string Observacoes { get; init; }
        public string Logradouro { get; init; } = default!;
        public string NomeLogradouro { get; init; } = default!;
        public string Numero { get; init; } = default!;
        public string Bairro { get; init; } = default!;
        public string Cidade { get; init; } = default!;
        public string Estado { get; init; } = default!;
        public string Cep { get; init; } = default!;

        public FornecedorEntity ToEntity()
        {
            var contato = Contato.Of(new Email(Email), new Telefone(Telefone), Observacoes);
            var endereco = Endereco.Of(Logradouro, NomeLogradouro, Numero, Bairro, Cidade, Estado, Cep);
            var fornecedor = FornecedorEntity.New(RazaoSocial, Fantasia, Cnpj, contato, endereco);
            fornecedor.Sanitize();
            return fornecedor;
        }
    }
}
