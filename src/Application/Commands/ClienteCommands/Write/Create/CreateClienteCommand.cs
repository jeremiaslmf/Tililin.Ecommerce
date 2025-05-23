using Tililin.Domain.Entities;
using Tililin.Domain.ValueObjects;
using Tililin.Shared.Extensions;

namespace Tililin.Application.Commands.ClienteCommands.Write.Create;

public class CreateClienteCommand : ClienteCommandBase
{
    public string Cpf { get; init; } = default!;

    public Cliente ToEntity()
    {
        var contato = Contato.Of(new Email(Email), new Telefone(Telefone), Observacoes);
        var endereco = Endereco.Of(Logradouro, NomeLogradouro, Numero, Bairro, Cidade, Estado, Cep);
        var cliente = Cliente.New(Nome, SobreNome, Cpf, DataNascimento, contato, endereco);
        cliente.Sanitize();
        return cliente;
    }
}
