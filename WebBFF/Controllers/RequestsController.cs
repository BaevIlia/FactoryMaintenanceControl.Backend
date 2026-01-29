using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebBFF.Usecases.Queries.GetRequest;

namespace WebBFF.Controllers;

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
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRequest([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetRequestQuery(id));

        return Ok(result);
    }
}