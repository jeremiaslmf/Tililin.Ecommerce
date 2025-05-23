using Tililin.Domain.ValueObjects;

namespace Tililin.Domain.Entities;

public class Cliente : EntityBase
{
    public short Idade { get; private set; }
    public string Cpf { get; private set; }
    public string Nome { get; private set; }
    public string SobreNome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public Contato Contato { get; private set; }
    public Endereco Endereco { get; private set; }

    public static Cliente New(
        string cpf,
        string nome,
        string sobreNome,
        DateTime dataNascimento,
        Contato contato,
        Endereco endereco) => new()
    {
        Cpf = cpf,
        Nome = nome,
        SobreNome = sobreNome,
        DataNascimento = dataNascimento,
        Contato = contato,
        Endereco = endereco,
    };

    public void Update(
        string nome, 
        string sobreNome, 
        short idade,  
        DateTime dataNascimento,
        Contato contato, 
        Endereco endereco)
    {
        Nome = nome;
        SobreNome = sobreNome;
        Idade = idade;
        DataNascimento = dataNascimento;
        Contato = contato;
        Endereco = endereco;
    }
}
