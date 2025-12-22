using MediatR;
using Microsoft.AspNetCore.Mvc;
using RequestsService.Application.Usecases.Requests.Queries;

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
    public async Task<IActionResult> GetRequests()
    {
        var result = await _mediator.Send(new GetRequestsQuery());

        return Ok(result);
    }
}