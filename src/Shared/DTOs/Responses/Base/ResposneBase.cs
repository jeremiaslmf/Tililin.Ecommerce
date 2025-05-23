namespace Tililin.Shared.DTOs.Responses.Base;

public abstract class ResposneBase
{
    public Guid PublicId { get; protected set; }

    protected ResposneBase(Guid publicId)
    {
        PublicId = publicId;
    }
}
