using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBFF.Application.Usecases.Commands.Auth;
using WebBFF.Usecases.Queries.Auth.GetUserData;

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
    public async Task<IActionResult> Auth([FromBody] AuthCommand request, CancellationToken cancellationToken)
    {
        var token = await _mediator.Send(request, cancellationToken);
        
        return Ok(token);
    }

    [HttpGet("userdata")]
    [Authorize]
    public async Task<IActionResult> GetUserData(CancellationToken cancellationToken = default)
    {
        var data = await _mediator.Send(new GetUserDataQuery(),  cancellationToken);
        
        return Ok(data);
    }
}