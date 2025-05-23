namespace Tililin.Domain.ValueObjects;

public class Email
{
    public string Valor { get; private set; }

    public Email(string valor)
    {
        valor = valor.ToLowerInvariant();

        if (string.IsNullOrWhiteSpace(valor) || !valor.Contains("@"))
            throw new ArgumentException("Email inválido.", nameof(valor));

        Valor = valor.Trim().ToLowerInvariant();
    }

    public Email()
    {
    }

    public override string ToString() => Valor;

    public override bool Equals(object obj) =>
        obj is Email outro && Valor == outro.Valor;

    public override int GetHashCode() => Valor.GetHashCode();
}
