using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteQuestor.DTOs.Boleto;
using TesteQuestor.Exceptions;
using TesteQuestor.Services;

namespace TesteQuestor.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class BoletosController(IBoletoService boletoService) : ControllerBase
{
    /// <summary>
    /// Busca o boleto pelo seu id. Devolve o valor com juros se vencido
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BoletoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BoletoResponse>> GetById(int id)
    {
        var boleto = await boletoService.GetByIdAsync(id);
        return boleto is null ? NotFound() : Ok(boleto);
    }

    /// <summary>
    /// Cria um novo registro de boleto
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(BoletoResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BoletoResponse>> Create([FromBody] CreateBoletoRequest request)
    {
        try
        {
            var created = await boletoService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (NotFoundException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
