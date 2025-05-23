namespace Tililin.Domain.ValueObjects;

public class Contato
{
    public Email Email { get; private set; }
    public Telefone Telefone { get; private set; }
    public string Observacoes { get; private set; }

    public static Contato Of(Email email, Telefone telefone, string observacoes = null) => new()
    {
        Email = email ?? throw new ArgumentNullException(nameof(email)),
        Telefone = telefone ?? throw new ArgumentNullException(nameof(telefone)),
        Observacoes = observacoes?.Trim(),
    };

    public Contato()
    {
    }

    public override bool Equals(object obj)
    {
        if (obj is not Contato outro) return false;

        return Email.Equals(outro.Email)
            && Telefone.Equals(outro.Telefone)
            && Observacoes == outro.Observacoes;
    }

    public override int GetHashCode() =>
        HashCode.Combine(Email, Telefone, Observacoes);
}
