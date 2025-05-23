using MediatR;
using Tililin.Shared.DTOs.Responses;

namespace Tililin.Application.Queries.Clientes;

public class GetClienteByIdQuery(Guid publicId) : IRequest<ClienteResponse>
{
    public Guid PublicId { get; set; } = publicId;
}
