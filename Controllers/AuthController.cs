using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteQuestor.DTOs.Auth;
using TesteQuestor.Services;

namespace TesteQuestor.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class AuthController(ITokenService tokenService) : ControllerBase
{
    /// <summary>
    /// Login simulado. Aceita qualquer usuário e senha não vazios, não valida credenciais reais,
    /// serve apenas para gerar um token JWT válido e permitir testar os endpoints protegidos.
    /// </summary>
    [HttpPost("token")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult LoginSimulado([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var response = tokenService.GenerateToken(request.Username);
        return Ok(response);
    }
}
