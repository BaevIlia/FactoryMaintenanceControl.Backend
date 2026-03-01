using AuthService.Application.Events;
using AuthService.Application.Usecases.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;

namespace AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IBus _bus;

    public AuthController(IMediator mediator, IBus bus)
    {
        _mediator = mediator;
        _bus = bus;
    }

    [HttpGet]
    public async Task<IActionResult> Ping()
    {
        return Ok("Good");
    }

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