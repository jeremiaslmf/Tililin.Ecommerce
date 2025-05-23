using Tililin.Domain.Entities;
using Tililin.Shared.DTOs.Responses.Base;

namespace Tililin.Shared.DTOs.Responses;

public class ClienteResponse : ResposneBase
{
    public ClienteResponse(Guid publicId) : base(publicId)
    {
    }

    public int Idade { get; set; }
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public string SobreNome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }

    public static ClienteResponse Of(Cliente cliente) => new(cliente.PublicId)
    {
        Cpf = cliente.Cpf,
        Nome = cliente.Nome,
        Idade = cliente.Idade,
        SobreNome = cliente.SobreNome,
        DataNascimento = cliente.DataNascimento,
        Telefone = cliente.Contato.Telefone.Numero,
        Endereco = cliente.Endereco.GetEndereco(),
    };
}
