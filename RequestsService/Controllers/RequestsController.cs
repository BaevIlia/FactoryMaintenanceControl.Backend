using Microsoft.AspNetCore.Mvc;

namespace RequestsService.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRequests(int id)
    {
        return Ok();
    }
}