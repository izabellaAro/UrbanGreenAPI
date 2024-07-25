using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbanGreen.Application.Models.Insumo;
using UrbanGreen.Application.Services.Interfaces;

namespace UrbanGreenAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InsumoController : ControllerBase
{
    private readonly IInsumoService _insumoService;

    public InsumoController(IInsumoService insumoService)
    {
        _insumoService = insumoService;
    }

    [Authorize(Roles = "Gerente,Admin")]
    [HttpPost]
    public async Task<IActionResult> CadastrarInsumo([FromBody] CreateInsumoDto insumoDto)
    {
        await _insumoService.CadastrarInsumo(insumoDto);
        return NoContent();
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpGet]
    public async Task<IEnumerable<ReadInsumoDto>> ConsultarInsumos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return await _insumoService.ConsultarInsumos(skip, take);
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpGet("{id}")]
    public async Task<IActionResult> ConsultarInsumoPorID(int id)
    {
        var insumo = await _insumoService.ConsultarInsumoPorID(id);
        if (insumo == null) return NotFound();
        return Ok(insumo);
    }

    [Authorize(Roles = "Gerente,Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarInsumo(int id, [FromBody] UpdateInsumoDto insumoDto)
    {
        var insumoAtualizado = await _insumoService.AtualizarInsumo(id, insumoDto);
        if (insumoAtualizado == false) return NotFound();
        return NoContent();
    }

    [Authorize(Roles = "Gerente,Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarInsumo(int id)
    {
        var insumo = await _insumoService.DeletarInsumo(id);
        if (insumo == false) return NotFound();
        return NoContent();
    }
}
