using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tililin.Application.Commands.UsuarioCommands.Write;
using Tililin.Domain.Enums;
using Tililin.Shared.DTOs.Responses;

namespace Tililin.API.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class UsuarioController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
        [FromBody] CreateUsuarioCommand command,
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(typeof(UsuarioLoginResponse), StatusCodes.Status200OK)]
    //[ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> Login(
        [FromBody] LoginUsuarioCommand command,
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPut("{publicId}/roles")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(UsuarioLoginResponse), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateRoles(
        Guid publicId,
        [FromBody] UserRoleType[] roles,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateUsuarioRolesCommand()
        {
            PublicId = publicId,
            Roles = roles
        };

        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }

}
