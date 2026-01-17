using Microsoft.AspNetCore.Mvc;

namespace WebBFF.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRequests()
    {
        return Ok();
    }
}