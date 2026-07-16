using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteQuestor.DTOs.Banco;
using TesteQuestor.Exceptions;
using TesteQuestor.Services;

namespace TesteQuestor.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class BancosController(IBancoService bancoService) : ControllerBase
{
    /// <summary>
    /// Busca todos os registros
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BancoResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BancoResponse>>> GetAll()
    {
        var bancos = await bancoService.GetAllAsync();
        return Ok(bancos);
    }

    /// <summary>
    /// Busca um único registro pelo código do banco
    /// </summary>
    [HttpGet("{codigoBanco}")]
    [ProducesResponseType(typeof(BancoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BancoResponse>> GetByCodigo(string codigoBanco)
    {
        var banco = await bancoService.GetByCodigoAsync(codigoBanco);
        return banco is null ? NotFound() : Ok(banco);
    }

    /// <summary>
    /// Cria um novo registro de banco
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(BancoResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<BancoResponse>> Create([FromBody] CreateBancoRequest request)
    {
        try
        {
            var created = await bancoService.CreateAsync(request);
            return CreatedAtAction(nameof(GetByCodigo), new { codigoBanco = created.CodigoBanco }, created);
        }
        catch (ConflictException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
}
