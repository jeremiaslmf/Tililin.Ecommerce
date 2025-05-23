using MediatR;

namespace Tililin.Application.Commands.Base;

public abstract class CommandBase<TResponse> : IRequest<TResponse>
{
}
