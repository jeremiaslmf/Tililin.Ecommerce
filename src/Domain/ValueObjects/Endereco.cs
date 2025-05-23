namespace Tililin.Domain.ValueObjects;

public class Endereco
{
    public string Logradouro { get; private set; }
    public string NomeLogradouro { get; set; }
    public string Numero { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public string CEP { get; private set; }

    public static Endereco Of(string logradouro,  string nomeLogradouro, string numero, string bairro, string cidade, string estado, string cep) => new()
    {
        NomeLogradouro = nomeLogradouro,
        Logradouro = logradouro,
        Numero = numero,
        Bairro = bairro,
        Cidade = cidade,
        Estado = estado,
        CEP = cep,
    };

    public override bool Equals(object obj)
    {
        if (obj is not Endereco outro) return false;

        return Logradouro == outro.Logradouro &&
               Numero == outro.Numero &&
               Bairro == outro.Bairro &&
               Cidade == outro.Cidade &&
               Estado == outro.Estado &&
               CEP == outro.CEP;
    }

    public string GetEndereco()
    {
        return $"{Logradouro}: {NomeLogradouro}, Número: {Numero}, Bairro: {Bairro} - Cidade: {Cidade}/{Estado}";
    }

    public override int GetHashCode() =>
        HashCode.Combine(Logradouro, Numero, Bairro, Cidade, Estado, CEP);
}

