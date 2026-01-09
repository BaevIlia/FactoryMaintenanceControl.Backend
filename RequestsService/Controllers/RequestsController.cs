using MediatR;
using Microsoft.AspNetCore.Mvc;
using RequestsService.Application.Usecases.Requests.Commands;
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

    [HttpGet()]
    public async Task<IActionResult> GetListByUser()
    {
        var result = await _mediator.Send(new GetRequestsByUserQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByUser([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetRequestByUserQuery(id));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRequest([FromBody] CreateRequestCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
}