using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tililin.Application.Commands.ClienteCommands.Write.Create;
using Tililin.Application.Commands.ClienteCommands.Write.Update;
using Tililin.Application.Queries.Clientes;
using Tililin.Shared.DTOs.Responses;

namespace Tililin.API.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class ClienteController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromBody] CreateClienteCommand command,
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = result.PublicId }, result);
    }

    [HttpPut("publicId:guid")]
    [Authorize]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(
        Guid publicId,
        [FromBody] UpdateClienteCommand command,
        CancellationToken cancellationToken = default)
    {
        if (command.PublicId != publicId)
            return BadRequest("PublicId do cliente não confere com o PublicId fornecido no corpo da requisição.");

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{publicId:guid}")]
    [Authorize]
    [ProducesResponseType(typeof(ClienteResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        Guid publicId,
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetClienteByIdQuery(publicId), cancellationToken);
        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
