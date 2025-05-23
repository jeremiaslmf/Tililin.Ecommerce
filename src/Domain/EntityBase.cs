namespace Tililin.Domain;

public abstract class EntityBase
{
    public EntityBase()
    {
        PublicId = Guid.NewGuid();
        DataCriacao = DateTime.UtcNow;
    }

    public long Id { get; protected set; }
    public Guid PublicId { get; protected set; }
    public bool Disabled { get; protected set; }
    public DateTime DataCriacao { get; protected set; }
    public DateTime AtualizadoEm { get; protected set; }

    protected void SetUpdated()
    {
        AtualizadoEm = DateTime.UtcNow;
    }

    public void Disable()
    {
        Disabled = true;
        SetUpdated();
    }
}
