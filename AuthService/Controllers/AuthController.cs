using AuthService.Application.Usecases.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
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

    [HttpPost("auth")]
    public async Task<IActionResult> Authentication()
    {
        throw new NotImplementedException();
    }
}