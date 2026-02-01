using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Ping()
    {
        return Ok("Good");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Registration()
    {
        throw new NotImplementedException();
    }

    [HttpPost("auth")]
    public async Task<IActionResult> Authentication()
    {
        throw new NotImplementedException();
    }
}