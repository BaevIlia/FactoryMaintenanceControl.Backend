using AuthService.Application.Events;
using AuthService.Application.Usecases.Commands;
using AuthService.Application.Usecases.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;

namespace AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator, IBus bus)
    {
        _mediator = mediator;
    }

    [HttpGet("ping")]
    public async Task<IActionResult> Ping()
    {
        return Ok("Good");
    }

    [HttpGet("userData")]
    public async Task<IActionResult> GetUserData([FromQuery] Guid userId, CancellationToken cancellationToken)
        => Ok(await _mediator.Send(new GetUserDataQuery(userId), cancellationToken));

    [HttpPost("register")]
    public async Task<IActionResult> Registration([FromBody] RegistrationCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}