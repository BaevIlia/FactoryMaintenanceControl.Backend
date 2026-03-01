using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebBFF.Usecases.Command.Auth;

namespace WebBFF.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Auth([FromBody] AuthCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}