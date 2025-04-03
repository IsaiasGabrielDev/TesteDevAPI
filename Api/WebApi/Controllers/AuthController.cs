using Core.Services.AuthenticateService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetUserByEmail(
        [FromServices] GetUserByEmailFunction function,
        CancellationToken cancellationToken)
    {
        string userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
        if (string.IsNullOrEmpty(userEmail))
            return Unauthorized("Usuário não autorizado");

        var user = await function(userEmail, cancellationToken);
        return user is not null
            ? Ok(user)
            : NotFound("Usuário não encontrado");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(
        [FromServices] LoginUserFunction function,
        [FromBody] Login login,
        CancellationToken cancellationToken)
    {
        var (isLogged, message) = await function(login, cancellationToken);
        return isLogged
            ? Ok(message)
            : BadRequest(message);
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
            : BadRequest(errorMessage);
    }
}
