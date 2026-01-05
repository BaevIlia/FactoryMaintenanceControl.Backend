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

    [HttpGet]
    public async Task<IActionResult> GetRequestsByUser([FromQuery] Guid userId)
    {
        var result = await _mediator.Send(new GetRequestsByUserQuery(userId));

        return Ok(result);
    }
}