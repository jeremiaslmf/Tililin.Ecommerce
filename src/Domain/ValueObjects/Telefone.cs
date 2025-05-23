namespace Tililin.Domain.ValueObjects;

public class Telefone
{
    public string Numero { get; private set; }

    public Telefone(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero) || numero.Length < 10)
            throw new ArgumentException("Telefone inválido.", nameof(numero));

        Numero = numero;
    }

    public override string ToString() => Numero;

    public override bool Equals(object obj) =>
        obj is Telefone outro && Numero == outro.Numero;

    public override int GetHashCode() => Numero.GetHashCode();
}
