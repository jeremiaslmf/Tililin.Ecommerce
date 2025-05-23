using Tililin.Application.Commands.Base;
using Tililin.Shared.DTOs.Responses;

namespace Tililin.Application.Commands.ClienteCommands.Write
{
    public abstract class ClienteCommandBase : CommandBase<ClienteResponse>
    {
        public string Nome { get; init; } = default!;
        public string SobreNome { get; init; } = default!;
        public short Idade { get; init ; } = default!;
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
        public DateTime DataNascimento { get; init; } = default!;
    }
}
