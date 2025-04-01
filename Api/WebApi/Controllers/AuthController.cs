using Core.Services.AuthenticateService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login(
        [FromServices] LoginUserFunction function,
        [FromBody] Login login,
        CancellationToken cancellationToken)
    {
        var (isLogged, message) = await function(login, cancellationToken);
        return isLogged
            ? Ok(message)
            : StatusCode(StatusCodes.Status500InternalServerError, message);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(
        [FromServices] RegisterUserFunction function,
        [FromBody] RegisterUser registerUser,
        CancellationToken cancellationToken)
    {
        var (user, errorMessage) = await function(registerUser, cancellationToken);
        return string.IsNullOrEmpty(errorMessage)
            ? Ok(user)
            : StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
    }
}
