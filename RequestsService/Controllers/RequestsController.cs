using MediatR;
using Microsoft.AspNetCore.Mvc;
using RequestsService.Application.Usecases.Requests.Queries;
using RequestsService.Application.Usecases.Requests.Queries.GetByUser;

namespace RequestsService.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetListByUser()
    {
        var result = await _mediator.Send(new GetRequestsByUserQuery());

        return Ok(result);
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetByUser([FromQuery] Guid requestId)
    {
        var result = await _mediator.Send(new GetRequestByUserQuery());

        return Ok(result);
    }
}